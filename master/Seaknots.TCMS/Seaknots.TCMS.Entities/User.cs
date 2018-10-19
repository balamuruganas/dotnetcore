using Seaknots.TCMS.Core.Concrete.Trackable;
using System.ComponentModel.DataAnnotations;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Company { get; set; }
  }
}
