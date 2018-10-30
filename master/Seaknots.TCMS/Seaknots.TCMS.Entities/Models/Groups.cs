using Seaknots.TCMS.Core.Concrete.Trackable;

namespace Seaknots.TCMS.Entities
{
  public class ExpenseGroup : Entity
  {
    public int GroupID { get; set; }
    public int ElementID { get; set; }
  }

  public class RevenueGroup : Entity
  {
    public int GroupID { get; set; }
    public int ShipmentTypeID { get; set; }
    public int ElementID { get; set; }
    public double TaxPercentage { get; set; }
  }

  public class ProductGroup : ListItem { }
}
