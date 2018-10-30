using Seaknots.TCMS.Core.Concrete.Trackable;

namespace Seaknots.TCMS.Entities
{
  public class Location : Entity
  {
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int RegionID { get; set; }
    public int CountryID { get; set; }
  }

  public class Region : ListItem { }

  public class Country : ListItem { }

  public class Currency : ListItem { }
}
