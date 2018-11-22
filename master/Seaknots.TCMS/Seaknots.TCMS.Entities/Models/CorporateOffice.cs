using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class CorporateOffice : Entity
  {
    public CorporateOffice()
    {
      Contacts = new Collection<Contact>();
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CoID { get; set; }
    [Key]
    public string GlobalID { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyTypeID { get; set; } = -1;
    public int CurrencyID { get; set; } = -1;
    public int CountryID { get; set; } = -1;
    public int LocationID { get; set; } = -1;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<BankInfo> BankInfo { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
    public Logo Logo { get; set; }
  }
}
