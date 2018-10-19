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
      CompanyTypeListItems = new Collection<ListItem>();
      CurrencyListItems = new Collection<ListItem>();
      CountryListItems = new Collection<ListItem>();
      LocationListItems = new Collection<ListItem>();
      Contacts = new Collection<Contact>();
    }

    public string GlobalID { get; set; }
    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public ListItem CompanyType { get; set; }
    public ListItem Currency { get; set; }
    public ListItem Country { get; set; }
    public ListItem Location { get; set; }
    public ICollection<ListItem> CompanyTypeListItems { get; set; }
    public ICollection<ListItem> CurrencyListItems { get; set; }
    public ICollection<ListItem> CountryListItems { get; set; }
    public ICollection<ListItem> LocationListItems { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public BankInfo BankInfo { get; set; }
    public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
    public virtual ICollection<CorporateOffice> Offices { get; set; }
  }

  public class ListItem
  {
    public int ID { get; set; }
    public string Text { get; }
    public string Value { get; }
  }

  public class Contact
  {
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int HP { get; set; }
  }

  public class BankInfo
  {
  }

  public class Logo
  {
    public string Name { get; set; }
    public string Url { get; set; }
  }
}
