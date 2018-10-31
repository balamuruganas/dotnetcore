using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class TaxView : BaseView
  {
    public IEnumerable<Tax> Items { get; set; }
  }
}
