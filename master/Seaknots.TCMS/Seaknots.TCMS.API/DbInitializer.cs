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

      if (!_ctx.Currencies.Any())
        AddCurrencies();

      if (!_ctx.CompanyTypes.Any())
        AddCompanyTypes();

      if (!_ctx.Locations.Any())
        AddLocations();

      if (!_ctx.Regions.Any())
        AddRegions();

      if (!_ctx.CorporateOffices.Any())
        AddCorporateOffices();
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

    private void AddCurrencies()
    {
      _ctx.Currencies.AddRange(new List<Currency>()
      {
        new Currency() { Text="USD", Value="US Dollar" },
        new Currency() { Text="INR", Value="Indian Rupees" },
        new Currency() { Text="Euro", Value="Europian Euro" },
        new Currency() { Text="GBP", Value="British Pound" }
      });
      _ctx.SaveChanges();
    }

    private void AddCompanyTypes()
    {
      _ctx.CompanyTypes.AddRange(new List<CompanyType>()
      {
        new CompanyType() { Text="CT1", Value="Company Type One" },
        new CompanyType() { Text="CT2", Value="Company Type Two" },
        new CompanyType() { Text="CT3", Value="Company Type Three" }
      });
      _ctx.SaveChanges();
    }

    private void AddLocations()
    {
      _ctx.Locations.AddRange(new List<Location>()
      {
        new Location() { Code="Loc1", Name="Location One", Country = _ctx.Countries.ToList()[0], Region=_ctx.Regions.FirstOrDefault(x => x.Value=="Chennai") },
        new Location() { Code="Loc2", Name="Location Two", Country = _ctx.Countries.ToList()[0], Region=_ctx.Regions.FirstOrDefault(x => x.Value=="Delhi") },
        new Location() { Code="Loc3", Name="Location Three", Country = _ctx.Countries.ToList()[1], Region=_ctx.Regions.FirstOrDefault(x => x.Value=="Newyork") }
      });
      _ctx.SaveChanges();
    }

    private void AddRegions()
    {
      _ctx.Regions.AddRange(new List<Region>()
      {
        new Region() { Text="IN", Value="Chennai" },
        new Region() { Text="IN", Value="Delhi" },
        new Region() { Text="US", Value="Newyork" },
        new Region() { Text="US", Value="Washigton DC" }
      });
      _ctx.SaveChanges();
    }

    private void AddCorporateOffices()
    {
      _ctx.CorporateOffices.AddRange(new List<CorporateOffice>()
      {
        new CorporateOffice() { GlobalID="CO1", ShortName="Corporate Office 1", CompanyName="Corporate Office One", CompanyType=_ctx.CompanyTypes.ToList()[0], Currency=_ctx.Currencies.ToList()[0], Country=_ctx.Countries.ToList()[0], Location=_ctx.Locations.ToList()[0], Email="co1@tcms.com", Address="1 Avenue, Chennai" },
        new CorporateOffice() { GlobalID="CO2", ShortName="Corporate Office 2", CompanyName="Corporate Office Two", CompanyType=_ctx.CompanyTypes.ToList()[1], Currency=_ctx.Currencies.ToList()[0], Country=_ctx.Countries.ToList()[0], Location =_ctx.Locations.ToList()[1], Email ="co2@tcms.com", Address="2 Avenue, Delhi" },
        new CorporateOffice() { GlobalID="CO3", ShortName="Corporate Office 3", CompanyName="Corporate Office Three", CompanyType=_ctx.CompanyTypes.ToList()[2], Currency=_ctx.Currencies.ToList()[1], Country =_ctx.Countries.ToList()[1], Location =_ctx.Locations.ToList()[2], Email ="co3@tcms.com", Address="3 Avenue, Newyork" }
      });
      _ctx.SaveChanges();
    }
  }
}
