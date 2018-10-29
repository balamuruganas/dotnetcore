using Seaknots.TCMS.Core.Concrete.Trackable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Location : Entity
  {
    public Location()
    {
      Regions = new Collection<Region>();
      Countries = new Collection<Country>();
    }

    [Key]
    public int ID { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Region Region { get; set; }
    public Country Country { get; set; }
    [NotMapped]
    public ICollection<Region> Regions { get; set; }
    [NotMapped]
    public ICollection<Country> Countries { get; set; }
  }
}
