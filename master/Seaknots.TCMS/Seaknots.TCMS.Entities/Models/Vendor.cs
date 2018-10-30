using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class Vendor : Entity
  {
    public Vendor()
    {
      Contacts = new Collection<Contact>();
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public int TankAgencyID { get; set; }
    public int CountryID { get; set; }
    public int LocationID { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int VendorTypeID { get; set; }
    public int StatusID { get; set; }
    public int CreditID { get; set; }
    public int CredentialID { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
