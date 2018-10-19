using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class Vendor : Entity
  {
    public Vendor()
    {
      Contacts = new Collection<Contact>();
      Agencies = new Collection<TankAgency>();
      Countries = new Collection<Country>();
      CustomerTypes = new Collection<CustomerType>();
      StatusList = new Collection<Status>();
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public TankAgency Agency { get; set; }
    public Country Country { get; set; }
    public Location Location { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public VendorType VendorType { get; set; }
    public Status Status { get; set; }
    public Credit Credit { get; set; }
    public Credentials Credentials { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<TankAgency> Agencies { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<CustomerType> CustomerTypes { get; set; }
    public ICollection<Status> StatusList { get; set; }
    public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
