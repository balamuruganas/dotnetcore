using Seaknots.TCMS.Core.Concrete.Trackable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class Location : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocID { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int RegionID { get; set; } = -1;
    public int CountryID { get; set; } = -1;
  }

  public class Region : ListItem { }

  public class Country : ListItem { }

  public class Currency : ListItem { }
}
