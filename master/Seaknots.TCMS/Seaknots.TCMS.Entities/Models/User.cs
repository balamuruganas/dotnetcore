using Seaknots.TCMS.Core.Concrete.Trackable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RoleID { get; set; } = -1;
    public int CompanyID { get; set; } = -1;
    public bool IsActive { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime ModifiedOn { get; set; } = DateTime.Now;
  }

  public class Role : Entity
  {
    public string Name { get; set; }
  }
}
