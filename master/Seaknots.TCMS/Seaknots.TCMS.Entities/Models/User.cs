using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public partial class User : Entity
  {
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int RoleID { get; set; }
    public int CompanyID { get; set; }
  }
}
