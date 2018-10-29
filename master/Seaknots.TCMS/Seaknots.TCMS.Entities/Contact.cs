using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Contact : Entity
  {
    public Contact()
    {
      Departments = new Collection<string>();
    }

    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int HP { get; set; }
    [NotMapped]
    public ICollection<string> Departments { get; set; }
  }
}
