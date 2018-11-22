using Seaknots.TCMS.Core.Concrete.Trackable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seaknots.TCMS.Entities
{
  public class ExpenseGroup : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GroupID { get; set; }
    public int ElementID { get; set; } = -1;
  }

  public class RevenueGroup : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GroupID { get; set; }
    public int ShipmentTypeID { get; set; } = -1;
    public int ElementID { get; set; } = -1;
    public double TaxPercentage { get; set; } = 0;
  }

  public class ProductGroup : ListItem { }
}
