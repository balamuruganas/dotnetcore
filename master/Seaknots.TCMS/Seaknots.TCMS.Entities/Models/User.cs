using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Key]
    public string Email { get; set; } = string.Empty;
    [Required]
    public int RoleID { get; set; } = -1;
    [Required]
    public int LocationID { get; set; } = -1;
    public int CompanyID { get; set; } = -1;
    public bool IsActive { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime ModifiedOn { get; set; } = DateTime.Now;
  }

  public class Role : Entity
  {
    [Key]
    public string Name { get; set; }
  }
}
