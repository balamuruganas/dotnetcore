using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    public User()
    {
      Companies = new Collection<Company>();
      Roles = new Collection<Role>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Company> Companies { get; set; }
  }
}
