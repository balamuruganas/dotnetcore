namespace Seaknots.TCMS.API.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Seaknots.TCMS.Core.Abstractions.EF;
  using Seaknots.TCMS.Entities;
  using Seaknots.TCMS.Service;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;

  [Route("api/tankoperators")]
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
    public IQueryable<TankOperator> Get() => _toService.TankOperators;

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

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] TankOperator to)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != to.ID)
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