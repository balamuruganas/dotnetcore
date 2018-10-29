using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class RevenueGroup : Entity
  {
    public RevenueGroup()
    {
      Elements = new Collection<string>();
      ShipmentTypes = new Collection<string>();
      Groups = new Collection<string>();
    }

    public string Group { get; set; }
    [NotMapped]
    public ICollection<string> Elements { get; set; }
    public double TaxPercentage { get; set; }
    [NotMapped]
    public ICollection<string> ShipmentTypes { get; set; }
    [NotMapped]
    public ICollection<string> Groups { get; set; }
  }
}
