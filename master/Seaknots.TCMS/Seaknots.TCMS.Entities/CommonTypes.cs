using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public abstract class ListItem
  {
    [Key]
    public int ID { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
  }

  public class BankInfo
  {
    [Key]
    public int ID { get; set; }
  }

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

  public class ProductGroup : ListItem {}

  public class CleaningMethod : ListItem {}

  public class Credit
  {
    [Key]
    public int ID { get; set; }
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

    [Key]
    public int ID { get; set; }
    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
    [NotMapped]
    public ICollection<string> CustomerCodes { get; set; }
    [NotMapped]
    public ICollection<string> CustomerNames { get; set; }
  }

  public class Credentials
  {
    [Key]
    public int ID { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }

  public class Followup
  {
    [Key]
    public int ID { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime AlertDate { get; set; }
  }

  public class Role
  {
    [Key]
    public int ID { get; set; }
  }

  public class Logo
  {
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
  }

  public class Tax
  {
    [Key]
    public int ID { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Percentage { get; set; } = 0;
  }
}
