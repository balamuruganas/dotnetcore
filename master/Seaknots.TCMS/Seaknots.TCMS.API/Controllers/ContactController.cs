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
  [Route("api/contact")]
  public class ContactController : ControllerBase
  {
    private readonly IContactService _contactService;
    private readonly IUnitOfWork _unitOfWork;

    public ContactController(IContactService contactService, IUnitOfWork unitOfWork)
    {
      _contactService = contactService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Contact> Get() => _contactService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public ContactView UI() => _contactService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var contact = await _contactService.FindAsync(id);
      if (contact == null)
        return NotFound();

      return Ok(contact);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != contact.ContactID)
        return BadRequest();

      _contactService.Edit(contact);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _contactService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _contactService.Add(contact);

      await _unitOfWork.SaveChangesAsync();

      return Ok(contact);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _contactService.Remove(id);

      await _unitOfWork.SaveChangesAsync();
      return Ok(id);
    }
  }
}