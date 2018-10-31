using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class TankOperator : Entity
  {
    public TankOperator()
    {
      Contacts = new Collection<Contact>();
      BankInfos = new Collection<BankInfo>();
      PortsCovered = new Collection<Port>();
      DepotsCovered = new Collection<Depot>();
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
    public int OperatorTypeID { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<BankInfo> BankInfos { get; set; }
    public ICollection<Port> PortsCovered { get; set; }
    public ICollection<Depot> DepotsCovered { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
