using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Key]
    public string Email { get; set; }
    [Required]
    public int RoleID { get; set; }
    [Required]
    public int LocationID { get; set; } = -1;
    public int CompanyID { get; set; } = -1;
    public bool IsActive { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime ModifiedOn { get; set; } = DateTime.Now;
  }

  public class Role : Entity
  {
	  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleID { get; set; }
    [Key]
    public string Name { get; set; }
  }
}
