using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class TankOperator : Entity
  {
    public TankOperator()
    {
      Countries = new Collection<Country>();
      Locations = new Collection<Location>();
      CompanyTypes = new Collection<CompanyType>();
      Contacts = new Collection<Contact>();
      BankInfos = new Collection<BankInfo>();
      PortsCovered = new Collection<Port>();
      DepotsCovered = new Collection<Depot>();
      Types = new Collection<OperatorType>();
    }

    [Key]
    public int ID { get; set; }
    public string ShortName { get; set; }
    public string CompanyName { get; set; }
    public CompanyType CompanyType { get; set; }
    public Currency Currency { get; set; }
    public Country Country { get; set; }
    public Location Location { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public OperatorType Type { get; set; }
    public Port Port { get; set; }
    public Depot Depot { get; set; }
    [NotMapped]
    public ICollection<Country> Countries { get; set; }
    [NotMapped]
    public ICollection<Location> Locations { get; set; }
    [NotMapped]
    public ICollection<CompanyType> CompanyTypes { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<BankInfo> BankInfos { get; set; }
    public ICollection<Port> PortsCovered { get; set; }
    public ICollection<Depot> DepotsCovered { get; set; }
    [NotMapped]
    public ICollection<OperatorType> Types { get; set; }
    //public ICollection<Dictionary<string, dynamic>> CustomFields { get; set; }
  }
}
