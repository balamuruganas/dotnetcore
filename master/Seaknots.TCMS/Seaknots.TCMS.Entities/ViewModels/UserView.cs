using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class UserView : BaseView
  {
    public IEnumerable<User> Items { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Company> Companies { get; set; }
    public ICollection<Location> Locations { get; set; }
  }
}
