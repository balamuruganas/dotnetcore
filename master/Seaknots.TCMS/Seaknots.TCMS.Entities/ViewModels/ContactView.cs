using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class ContactView : BaseView
  {
    public IEnumerable<Contact> Items { get; set; }
  }
}
