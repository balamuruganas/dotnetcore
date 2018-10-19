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

      if (!_ctx.Products.Any())
      {
        _ctx.Products.AddRange(new List<Product>()
                {
                     new Product()
                     {
                         Id = 0,
                         Name = "P1",
                         Price = (decimal)1.5,
                         Category = "Cat1"
                     }, new Product()
                    {
                        Id = 0,
                        Name = "P1",
                        Price = (decimal)1.5,
                        Category = "Cat1"
                    },
                    new Product()
                    {
                        Id = 0,
                        Name = "P1",
                        Price = (decimal)1.5,
                        Category = "Cat1"
                    }, new Product()
                    {
                        Id = 0,
                        Name = "P1",
                        Price = (decimal)1.5,
                        Category = "Cat1"
                    }, new Product()
                    {
                        Id = 0,
                        Name = "P1",
                        Price = (decimal)1.5,
                        Category = "Cat1"
                    }
                });

        _ctx.SaveChanges();
      }
    }
  }
}
