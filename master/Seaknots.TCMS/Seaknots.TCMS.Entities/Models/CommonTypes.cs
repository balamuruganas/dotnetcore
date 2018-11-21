using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public abstract class ListItem :Entity
  {
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
  }

  public class Port : ListItem {}

  public class Depot : ListItem {}

  public class CompanyType : ListItem {}

  public class OperatorType : ListItem {}

  public class CustomerType : ListItem {}

  public class VendorType : ListItem {}

  public class Status : ListItem {}

  public class Company : ListItem {}

  public class Code : ListItem {}

  public class CleaningMethod : ListItem {}

  public class Credit : Entity
  {
    public int Days { get; set; } = 0;
    public double Amount { get; set; } = 0;
  }

  public class Affliates : Entity
  {
    public int CustomerCodeID { get; set; } = 0;
    public int CustomerNameID { get; set; } = 0;
  }

  public class Credentials : Entity
  {
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }

  public class Followup : Entity
  {
    public string Comment { get; set; } = string.Empty;
    public DateTime AlertDate { get; set; }
  }

  public class Logo
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LogoID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
  }
}
