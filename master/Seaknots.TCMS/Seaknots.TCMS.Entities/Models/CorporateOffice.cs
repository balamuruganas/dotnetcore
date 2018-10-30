using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public class CorporateOffice : Entity
  {
    public CorporateOffice()
    {
      Contacts = new Collection<Contact>();
    }

    public string GlobalID { get; set; }
    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public int CompanyTypeID { get; set; }
    public int CurrencyID { get; set; }
    public int CountryID { get; set; }
    public int LocationID { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public BankInfo BankInfo { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
    public Logo Logo { get; set; }
  }
}
