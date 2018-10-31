using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class CustomerView : BaseView
  {
    public IEnumerable<Customer> Items { get; set; }
    public ICollection<TankAgency> TankAgencies { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<CustomerType> CustomerTypes { get; set; }
    public ICollection<Status> Status { get; set; }
    public ICollection<Credit> Credits { get; set; }
    public ICollection<Credentials> Credentials { get; set; }
  }
}
