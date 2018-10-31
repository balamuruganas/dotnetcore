using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class LocationView : BaseView
  {
    public IEnumerable<Location> Items { get; set; }
    public ICollection<Region> Regions { get; set; }
    public ICollection<Country> Countries { get; set; }
  }
}
