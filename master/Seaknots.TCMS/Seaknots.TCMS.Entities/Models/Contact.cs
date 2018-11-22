using Seaknots.TCMS.Core.Concrete.Trackable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Contact : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContactID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public int DepartmentID { get; set; } = -1;
    public string Email { get; set; } = string.Empty;
    public int HP { get; set; } = 0;
  }
}
