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
  [Route("api/tankagency")]
  public class TankAgencyController : ControllerBase
  {
    private readonly ITankAgencyService _taService;
    private readonly IUnitOfWork _unitOfWork;

    public TankAgencyController(ITankAgencyService taService, IUnitOfWork unitOfWork)
    {
      _taService = taService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<TankAgency> Get() => _taService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public TankAgencyView UI() => _taService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var tas = await _taService.FindAsync(id);
      if (tas == null)
        return NotFound();

      return Ok(tas);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] TankAgency ta)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != ta.TaID)
        return BadRequest();

      _taService.Edit(ta);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _taService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return Ok(ta);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TankAgency ta)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _taService.Add(ta);
      await _unitOfWork.SaveChangesAsync();
      return Ok(ta);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _taService.Remove(id);
      await _unitOfWork.SaveChangesAsync();
      return Ok(id);
    }
  }
}
