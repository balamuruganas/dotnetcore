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
  [Route("api/user")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserService userService, IUnitOfWork unitOfWork)
    {
      _userService = userService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<User> Get() => _userService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public UserView UI() => _userService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = await _userService.FindAsync(id);
      if (user == null)
        return NotFound();

      return Ok(user);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] User user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != user.UserID)
        return BadRequest();

      _userService.Edit(user);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _userService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _userService.Add(user);
      await _unitOfWork.SaveChangesAsync();
      return Ok(user);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _userService.Remove(id);
      await _unitOfWork.SaveChangesAsync();
      return Ok(id);
    }
  }
}
