
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.Core.Abstractions.EF;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Service;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Seaknots.TCMS.API.Controllers
{
  [Route("api/vendors")]
  public class VendorController : ControllerBase
  {
    private readonly IVendorService _vendorService;

    private readonly IUnitOfWork _unitOfWork;

    public VendorController(IVendorService vendorService, IUnitOfWork unitOfWork)
    {
      _vendorService = vendorService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Vendor> Get() => _vendorService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var vendor = await _vendorService.FindAsync(id);
      if (vendor == null)
        return NotFound();

      return Ok(vendor);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Vendor vendor)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != vendor.ID)
        return BadRequest();

      _vendorService.Update(vendor);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _vendorService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Vendor vendor)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _vendorService.Insert(vendor);
      await _unitOfWork.SaveChangesAsync();

      return Ok(vendor);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _vendorService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}
