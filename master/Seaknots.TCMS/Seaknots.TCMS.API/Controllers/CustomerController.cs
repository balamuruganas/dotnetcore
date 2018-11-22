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
  [Route("api/customer")]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerService _customerService;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(ICustomerService customerService, IUnitOfWork unitOfWork)
    {
      _customerService = customerService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Customer> Get() => _customerService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("/ui")]
    public CustomerView UI() => _customerService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var customer = await _customerService.FindAsync(id);
      if (customer == null)
        return NotFound();

      return Ok(customer);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Customer customer)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != customer.CustomerID)
        return BadRequest();

      _customerService.Update(customer);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _customerService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Customer customer)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _customerService.Insert(customer);
      await _unitOfWork.SaveChangesAsync();
      return Ok(customer);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _customerService.DeleteAsync(id);
      if (!result)
        return NotFound();

      await _unitOfWork.SaveChangesAsync();
      return StatusCode((int)HttpStatusCode.NoContent);
    }
  }
}
