using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public class CorporateOffice : Entity
  {
    public CorporateOffice()
    {
      Offices = new Collection<CorporateOffice>();
      CompanyTypes = new Collection<CompanyType>();
      Currencies = new Collection<Currency>();
      Countries = new Collection<Country>();
      Locations = new Collection<Location>();
      Contacts = new Collection<Contact>();
    }

    public string GlobalID { get; set; }
    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public CompanyType CompanyType { get; set; }
    public Currency Currency { get; set; }
    public Country Country { get; set; }
    public Location Location { get; set; }
    public ICollection<CompanyType> CompanyTypes { get; set; }
    public ICollection<Currency> Currencies { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Location> Locations { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public BankInfo BankInfo { get; set; }
    public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
    public Logo Logo { get; set; }
    public virtual ICollection<CorporateOffice> Offices { get; set; }
  }
}
