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
  [Route("api/product")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IProductService productService, IUnitOfWork unitOfWork)
    {
      _productService = productService;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IQueryable<Product> Get() => _productService.GetModel().Items.AsQueryable();

    [HttpGet]
    [Route("ui")]
    public ProductView UI() => _productService.GetModel();

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var product = await _productService.FindAsync(id);
      if (product == null)
        return NotFound();

      return Ok(product);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] Product product)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (id != product.ProdID)
        return BadRequest();

      _productService.Edit(product);
      try
      {
        await _unitOfWork.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await _productService.ExistsAsync(id))
          return NotFound();

        throw;
      }

      return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _productService.Add(product);
      await _unitOfWork.SaveChangesAsync();
      return Ok(product);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _productService.Remove(id);
      await _unitOfWork.SaveChangesAsync();
      return Ok(id);
    }
  }
}
