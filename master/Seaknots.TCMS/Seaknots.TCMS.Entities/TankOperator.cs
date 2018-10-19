using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class TankOperator : Entity
  {
    public TankOperator()
    {
      Countries = new Collection<ListItem>();
      Locations = new Collection<ListItem>();
      CompanyTypes = new Collection<ListItem>();
      Contacts = new Collection<Contact>();
      BankInfos = new Collection<BankInfo>();
      PortsCovered = new Collection<ListItem>();
      DepotsCovered = new Collection<ListItem>();
      Types = new Collection<ListItem>();
      Operators = new Collection<TankOperator>();
    }

    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public ListItem CompanyType { get; set; }
    public ListItem Currency { get; set; }
    public ListItem Country { get; set; }
    public ListItem Location { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public ListItem Type { get; set; }
    public ListItem Port { get; set; }
    public ListItem Depot { get; set; }
    public ICollection<ListItem> Countries { get; set; }
    public ICollection<ListItem> Locations { get; set; }
    public ICollection<ListItem> CompanyTypes { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<BankInfo> BankInfos { get; set; }
    public ICollection<ListItem> PortsCovered { get; set; }
    public ICollection<ListItem> DepotsCovered { get; set; }
    public ICollection<ListItem> Types { get; set; }
    public ICollection<TankOperator> Operators { get; set; }
  }
}
