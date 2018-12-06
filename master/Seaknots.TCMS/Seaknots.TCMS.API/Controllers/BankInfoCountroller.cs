using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.Core.Abstractions.EF;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Service;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Seaknots.TCMS.API.Controllers
{
  [Route("api/bankinfo")]
  public class BankInfoController : ControllerBase
  {
    private readonly IBankInfoService _bankService;
    private readonly IUnitOfWork _unitOfWork;

    public BankInfoController(IBankInfoService bankService, IUnitOfWork unitOfWork)
    {
      _bankService = bankService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<BankInfo> Get() => _bankService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public BankInfoView UI() => _bankService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var bankinfo = await _bankService.FindAsync(id);
      if (bankinfo == null)
        return NotFound();

      return Ok(bankinfo);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] BankInfo bankinfo)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != bankinfo.BankID)
        return BadRequest();

      _bankService.Update(bankinfo);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _bankService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BankInfo bankinfo)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _bankService.Add(bankinfo);

      await _unitOfWork.SaveChangesAsync();

      return Ok(bankinfo);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _bankService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}