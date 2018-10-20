using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public class Contact
  {
    public Contact()
    {
      Departments = new Collection<string>();
    }

    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int HP { get; set; }
    public ICollection<string> Departments { get; set; }
  }

  public class Location
  {
    public Location()
    {
      Regions = new Collection<Region>();
      Countries = new Collection<Country>();
    }

    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Region Region { get; set; }
    public Country Country { get; set; }
    public ICollection<Region> Regions { get; set; }
    public ICollection<Country> Countries { get; set; }
  }

  public class RevenueGroup
  {
    public RevenueGroup()
    {
      Elements = new Collection<string>();
      ShipmentTypes = new Collection<string>();
      Groups = new Collection<string>();
    }

    public string Group { get; set; }
    public ICollection<string> Elements { get; set; }
    public double TaxPercentage { get; set; }
    public ICollection<string> ShipmentTypes { get; set; }
    public ICollection<string> Groups { get; set; }
  }


  public class ExpenseGroup
  {
    public ExpenseGroup()
    {
      Groups = new Collection<string>();
      Elememts = new Collection<string>();
    }

    public string Group { get; set; }
    public ICollection<string> Groups { get; set; }
    public ICollection<string> Elememts { get; set; }
  }

  public abstract class ListItem
  {
    public int ID { get; set; } = 0;
    public string Text { get; } = string.Empty;
    public string Value { get; } = string.Empty;
  }

  public class BankInfo {}

  public class Country : ListItem {}

  public class Currency : ListItem {}

  public class Region : ListItem {}

  public class Port : ListItem {}

  public class Depot : ListItem {}

  public class CompanyType : ListItem {}

  public class OperatorType : ListItem {}

  public class CustomerType : ListItem {}

  public class VendorType : ListItem {}

  public class Status : ListItem {}

  public class Company : ListItem {}

  public class Code : ListItem {}

  public class Credit
  {
    public int Days { get; set; } = 0;
    public double Amount { get; set; } = 0;
  }

  public class Affliates
  {
    public Affliates()
    {
      CustomerCodes = new Collection<string>();
      CustomerNames = new Collection<string>();
    }

    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    public ICollection<string> CustomerCodes { get; set; }
    public ICollection<string> CustomerNames { get; set; }
  }

  public class Credentials
  {
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }

  public class Followup
  {
    public string Comment { get; set; } = string.Empty;
    public DateTime AlertDate { get; set; }
  }

  public class Role
  {
  }

  public class Logo
  {
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
  }

  public class Tax
  {
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Percentage { get; set; } = 0;
  }
}
