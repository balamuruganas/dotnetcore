﻿
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
  [Route("api/vendor")]
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
    [Route("ui")]
    public VendorView UI() => _vendorService.GetModel();

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

      if (id != vendor.VendorID)
        return BadRequest();

      _vendorService.Edit(vendor);
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

      return Ok(vendor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Vendor vendor)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _vendorService.Add(vendor);
      await _unitOfWork.SaveChangesAsync();
      return Ok(vendor);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _vendorService.Remove(id);
      await _unitOfWork.SaveChangesAsync();
      return Ok(id);
    }
  }
}
