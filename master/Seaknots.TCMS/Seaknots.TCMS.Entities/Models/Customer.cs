using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class Customer : Entity
  {
    public Customer()
    {
      Followups = new Collection<Followup>();
      AffliatesList = new Collection<Affliates>();
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public int TankAgencyID { get; set; }
    public int CountryID { get; set; }
    public int LocationID { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int CustomerTypeID { get; set; }
    public int StatusID { get; set; }
    public int CreditID { get; set; }
    public int CredentialID { get; set; }

    public ICollection<Followup> Followups { get; set; }
    public ICollection<Affliates> AffliatesList { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
