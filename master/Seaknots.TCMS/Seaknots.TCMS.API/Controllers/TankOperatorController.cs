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
  [Route("api/tankoperator")]
  public class TankOperatorController : ControllerBase
  {
    private readonly ITankOperatorService _toService;
    private readonly IUnitOfWork _unitOfWork;

    public TankOperatorController(ITankOperatorService toService, IUnitOfWork unitOfWork)
    {
      _toService = toService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<TankOperator> Get() => _toService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var tos = await _toService.FindAsync(id);
      if (tos == null)
        return NotFound();

      return Ok(tos);
    }

    [HttpGet]
    [Route("ui")]
    public TankOperatorView UI() => _toService.GetModel();

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] TankOperator to)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != to.ToID)
        return BadRequest();

      _toService.Update(to);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _toService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TankOperator to)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _toService.Insert(to);
      await _unitOfWork.SaveChangesAsync();
      return Ok(to);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _toService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}
