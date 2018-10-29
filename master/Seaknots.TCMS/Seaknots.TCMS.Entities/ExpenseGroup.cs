using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class ExpenseGroup : Entity
  {
    public ExpenseGroup()
    {
      Groups = new Collection<string>();
      Elememts = new Collection<string>();
    }

    public string Group { get; set; }
    [NotMapped]
    public ICollection<string> Groups { get; set; }
    [NotMapped]
    public ICollection<string> Elememts { get; set; }
  }
}
