using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    public User()
    {
      Companies = new Collection<Company>();
      Roles = new Collection<Role>();
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    [NotMapped]
    public ICollection<Role> Roles { get; set; }
    [NotMapped]
    public ICollection<Company> Companies { get; set; }
  }
}
