﻿using Microsoft.AspNetCore.Mvc;
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
  [Route("api/tax")]
  public class TaxController : ControllerBase
  {
    private readonly ITaxService _taxService;
    private readonly IUnitOfWork _unitOfWork;

    public TaxController(ITaxService taxService, IUnitOfWork unitOfWork)
    {
      _taxService = taxService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Tax> Get() => _taxService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("/ui")]
    public TaxView UI() => _taxService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var tax = await _taxService.FindAsync(id);
      if (tax == null)
        return NotFound();

      return Ok(tax);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Tax tax)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != tax.TaxID)
        return BadRequest();

      _taxService.Update(tax);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _taxService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tax tax)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _taxService.Insert(tax);
      await _unitOfWork.SaveChangesAsync();
      return Ok(tax);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _taxService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}
