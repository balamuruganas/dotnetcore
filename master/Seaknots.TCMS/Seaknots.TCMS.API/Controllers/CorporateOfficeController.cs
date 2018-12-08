using Microsoft.AspNetCore.Cors;
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
  [Route("api/corporateoffice")]
  public class CorporateOfficeController : ControllerBase
  {
    private readonly ICorporateOfficeService _coService;
    private readonly IUnitOfWork _unitOfWork;

    public CorporateOfficeController(ICorporateOfficeService coService, IUnitOfWork unitOfWork)
    {
      _coService = coService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<CorporateOffice> Get() => _coService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public CorporateOfficeView UI() => _coService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var cos = await _coService.FindAsync(id);
      if (cos == null)
        return NotFound();

      return Ok(cos);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] CorporateOffice co)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != co.CoID)
        return BadRequest();

      _coService.Edit(co);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _coService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return Ok(co);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CorporateOffice co)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _coService.Add(co);

      await _unitOfWork.SaveChangesAsync();

      return Ok(co);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _coService.Remove(id);

      await _unitOfWork.SaveChangesAsync();

      return Ok(id);
    }
  }
}