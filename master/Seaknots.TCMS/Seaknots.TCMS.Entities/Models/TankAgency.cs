using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public class OperatorProp : Entity
  {
    public int OperatorID { get; set; } = -1;
    public DateTime ValidFrom { get; set; } = DateTime.Now;
    public DateTime ValidTill { get; set; } = DateTime.Now;
    public double ExportCom { get; set; } = 0;
    public double ImportCom { get; set; } = 0;
    public double MinCom { get; set; } = 0;
  }

  public partial class TankAgency : Entity
  {
    public TankAgency()
    {
      Operators = new Collection<OperatorProp>();
      Contacts = new Collection<Contact>();
    }

    public string ShortName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyTypeID { get; set; } = -1;
    public int CurrencyID { get; set; } = -1;
    public int CountryID { get; set; } = -1;
    public int LocationID { get; set; } = -1;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public BankInfo AcountDetail { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<OperatorProp> Operators { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
