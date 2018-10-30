using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class OperatorProp
  {
    public int OperatorID { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTill { get; set; }
    public double ExportCom { get; set; }
    public double ImportCom { get; set; }
    public double MinCom { get; set; }
  }

  public partial class TankAgency : Entity
  {
    public TankAgency()
    {
      Operators = new Collection<OperatorProp>();
      Contacts = new Collection<Contact>();
    }

    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public int CompanyTypeID { get; set; }
    public int CurrencyID { get; set; }
    public int CountryID { get; set; }
    public int LocationID { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public BankInfo AcountDetail { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<OperatorProp> Operators { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
