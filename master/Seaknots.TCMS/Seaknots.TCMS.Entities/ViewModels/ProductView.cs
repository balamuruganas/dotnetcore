using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class ProductView : BaseView
  {
    public IEnumerable<Product> Items { get; set; }
    public ICollection<ProductGroup> ProductGroups { get; set; }
    public ICollection<Code> ProductCodes { get; set; }
    public ICollection<Status> ProductStatus { get; set; }
  }
}
