using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.DataAccess;
using Seaknots.TCMS.Entities;

namespace Seaknots.TCMS.API
{
  public class DbInitializer
  {
    private readonly TCMSContext _ctx;

    public DbInitializer(TCMSContext ctx)
    {
      _ctx = ctx;
    }

    public void Initialize()
    {
      // Run Migrations
      if (!_ctx.Database.EnsureCreated())
        _ctx.Database.Migrate();

      if (!_ctx.Countries.Any())
        AddCountries();

      if (!_ctx.ProductGroups.Any())
        AddProductGroups();

      if (!_ctx.ProductNames.Any())
        AddProductNames();
    }

    private void AddCountries()
    {
      _ctx.Countries.AddRange(new List<Country>()
        {
          new Country() { Text="IN", Value="India" },
          new Country() { Text="US", Value="United States" },
          new Country() { Text="UK", Value="United Kingdom" },
          new Country() { Text="FR", Value="France" },
          new Country() { Text="ES", Value="Spain" }
        });
      _ctx.SaveChanges();
    }

    private void AddProductGroups()
    {
      _ctx.ProductGroups.AddRange(new List<ProductGroup>()
        {
          new ProductGroup() { Text="PG1", Value="Product Group One" },
          new ProductGroup() { Text="PG2", Value="Product Group Two" },
          new ProductGroup() { Text="PG3", Value="Product Group Three" }
        });
      _ctx.SaveChanges();
    }

    private void AddProductNames()
    {
      _ctx.ProductNames.AddRange(new List<Code>()
        {
          new Code() { Text="PN1", Value="Product Name One" },
          new Code() { Text="PN2", Value="Product Name Two" },
          new Code() { Text="PN3", Value="Product Name Three" }
        });
      _ctx.SaveChanges();
    }
  }
}
