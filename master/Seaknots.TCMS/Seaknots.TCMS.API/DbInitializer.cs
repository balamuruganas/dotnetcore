using System.Collections.Generic;
using System.Linq;
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
      _ctx.Database.EnsureCreated();
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

      if (!_ctx.Banks.Any())
        AddBanks();

      if (!_ctx.Logos.Any())
        AddLogos();

      if (!_ctx.Contacts.Any())
        AddContacts();

      if (!_ctx.CorporateOffices.Any())
        AddCorporateOffices();

      if (!_ctx.Roles.Any())
        AddRoles();

      if (!_ctx.Users.Any())
        AddUsers();
    }

    private void AddCountries()
    {
      _ctx.Countries.AddRange(new List<Country>()
        {
          new Country() { Name="IN", Value="India" },
          new Country() { Name="US", Value="United States" },
          new Country() { Name="UK", Value="United Kingdom" },
          new Country() { Name="FR", Value="France" },
          new Country() { Name="ES", Value="Spain" }
        });
    }

    private void AddProductGroups()
    {
      _ctx.ProductGroups.AddRange(new List<ProductGroup>()
        {
          new ProductGroup() { Name="PG1", Value="Product Group One" },
          new ProductGroup() { Name="PG2", Value="Product Group Two" },
          new ProductGroup() { Name="PG3", Value="Product Group Three" }
        });
      _ctx.SaveChanges();
    }

    private void AddProductNames()
    {
      _ctx.ProductNames.AddRange(new List<Code>()
        {
          new Code() { Name="PN1", Value="Product Name One" },
          new Code() { Name="PN2", Value="Product Name Two" },
          new Code() { Name="PN3", Value="Product Name Three" }
        });
      _ctx.SaveChanges();
    }

    private void AddCurrencies()
    {
      _ctx.Currencies.AddRange(new List<Currency>()
      {
        new Currency() { Name="USD", Value="US Dollar" },
        new Currency() { Name="INR", Value="Indian Rupees" },
        new Currency() { Name="Euro", Value="Europian Euro" },
        new Currency() { Name="GBP", Value="British Pound" }
      });
      _ctx.SaveChanges();
    }

    private void AddCompanyTypes()
    {
      _ctx.CompanyTypes.AddRange(new List<CompanyType>()
      {
        new CompanyType() { Name="CT1", Value="Company Type One" },
        new CompanyType() { Name="CT2", Value="Company Type Two" },
        new CompanyType() { Name="CT3", Value="Company Type Three" }
      });
      _ctx.SaveChanges();
    }

    private void AddLocations()
    {
      _ctx.Locations.AddRange(new List<Location>()
      {
        new Location() { Code="Loc1", Name="Location One", CountryID = 0, RegionID=0 },
        new Location() { Code="Loc2", Name="Location Two", CountryID = 0, RegionID=1 },
        new Location() { Code="Loc3", Name="Location Three", CountryID = 0, RegionID=2 }
      });
      _ctx.SaveChanges();
    }

    private void AddRegions()
    {
      _ctx.Regions.AddRange(new List<Region>()
      {
        new Region() { Name="IN", Value="Chennai" },
        new Region() { Name="IN", Value="Delhi" },
        new Region() { Name="US", Value="Newyork" },
        new Region() { Name="US", Value="Washigton DC" }
      });
      _ctx.SaveChanges();
    }

    private void AddCorporateOffices()
    {
      var banks = _ctx.Banks;
      var contacts = _ctx.Contacts;
      _ctx.CorporateOffices.AddRange(new List<CorporateOffice>()
      {
        new CorporateOffice() { GlobalID="CO1", ShortName="Corporate Office 1", CompanyName="Corporate Office One", CompanyTypeID=0, CurrencyID=0, CountryID=0, LocationID=0, Email="co1@tcms.com", Address="1 Avenue, Chennai", BankInfo=banks.ToList(), Contacts=contacts.ToList() },
        new CorporateOffice() { GlobalID="CO2", ShortName="Corporate Office 2", CompanyName="Corporate Office Two", CompanyTypeID=1, CurrencyID=0, CountryID=0, LocationID =1, Email ="co2@tcms.com", Address="2 Avenue, Delhi", BankInfo = banks.ToList(), Contacts=contacts.ToList() },
        new CorporateOffice() { GlobalID="CO3", ShortName="Corporate Office 3", CompanyName="Corporate Office Three", CompanyTypeID=2, CurrencyID=1, CountryID=1, LocationID =2, Email ="co3@tcms.com", Address="3 Avenue, Newyork", BankInfo=banks.ToList(), Contacts=contacts.ToList() }
      });
      _ctx.SaveChanges();
    }

    private void AddRoles()
    {
      _ctx.Roles.AddRange(new List<Role>()
      {
        new Role() { Name = "Admin" },
        new Role() { Name = "User" }
      });
      _ctx.SaveChanges();
    }

    private void AddUsers()
    {
      _ctx.Users.AddRange(new List<User>()
      {
        new User() { Name="Amresh Kumar", Email="kumar.anirudha@gmail.com", Password="aks", RoleID=0, CompanyID=0, IsActive=true, LocationID=0 },
        new User() { Name="Kumar Anirudha", Email="kumar.anirudha@hotmail.com", Password="aks", RoleID=1, CompanyID=1, IsActive=true,LocationID=1 }
      });
      _ctx.SaveChanges();
    }

    private void AddBanks()
    {
      _ctx.Banks.AddRange(new List<BankInfo>()
      {
        new BankInfo() { AccountNumber="01234", BankName="National Bank 1", HolderName="Amresh Kumar", BranchIFSC="NB001"},
        new BankInfo() { AccountNumber="02345", BankName="National Bank 2", HolderName="Amresh Kumar", BranchIFSC="NB002"}
      });
      _ctx.SaveChanges();
    }

    private void AddLogos()
    {
      _ctx.Logos.AddRange(new List<Logo>()
      {
        new Logo()
      });
      _ctx.SaveChanges();
    }

    private void AddContacts()
    {
      _ctx.Contacts.AddRange(new List<Contact>()
      {
        new Contact() { DepartmentID = 0, Designation = "TD1", Email = "t1@tcms.com", HP = 12, Name = "Test Contact 2" },
        new Contact() { DepartmentID = 1, Designation = "TD2", Email = "t2@tcms.com", HP = 12, Name = "Test Contact 1" }
      });
      _ctx.SaveChanges();
    }
  }
}
