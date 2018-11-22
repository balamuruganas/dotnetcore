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
  [Route("api/location")]
  public class LocationController : ControllerBase
  {
    private readonly ILocationService _locationService;
    private readonly IUnitOfWork _unitOfWork;

    public LocationController(ILocationService locationService, IUnitOfWork unitOfWork)
    {
      _locationService = locationService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Location> Get() => _locationService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public LocationView UI() => _locationService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var location = await _locationService.FindAsync(id);
      if (location == null)
        return NotFound();

      return Ok(location);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Location location)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != location.LocID)
        return BadRequest();

      _locationService.Update(location);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _locationService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Location location)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _locationService.Insert(location);
      await _unitOfWork.SaveChangesAsync();
      return Ok(location);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _locationService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}
