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
      Contacts = new HashSet<Contact>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VendorID { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int TankAgencyID { get; set; } = -1;
    public int CountryID { get; set; } = -1;
    public int LocationID { get; set; } = -1;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int VendorTypeID { get; set; } = -1;
    public int StatusID { get; set; } = -1;
    public int CreditID { get; set; } = -1;
    public int CredentialID { get; set; } = -1;
    public ICollection<Contact> Contacts { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
