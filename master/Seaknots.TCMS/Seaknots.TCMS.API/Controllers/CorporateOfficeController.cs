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

  [Route("api/corporateoffices")]
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
    public IQueryable<CorporateOffice> Get() => _coService.CorporateOffices;

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

      if (id != co.ID)
        return BadRequest();

      _coService.Update(co);

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

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CorporateOffice co)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _coService.Insert(co);
      await _unitOfWork.SaveChangesAsync();

      return Ok(co);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _coService.DeleteAsync(id);

      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();

      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}