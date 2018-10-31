using Seaknots.TCMS.Core.Concrete.Trackable;

namespace Seaknots.TCMS.Entities
{
  public class ExpenseGroup : Entity
  {
    public int GroupID { get; set; } = -1;
    public int ElementID { get; set; } = -1;
  }

  public class RevenueGroup : Entity
  {
    public int GroupID { get; set; } = -1;
    public int ShipmentTypeID { get; set; } = -1;
    public int ElementID { get; set; } = -1;
    public double TaxPercentage { get; set; } = 0;
  }

  public class ProductGroup : ListItem { }
}
