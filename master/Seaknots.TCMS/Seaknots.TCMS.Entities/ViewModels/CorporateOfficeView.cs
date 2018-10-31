using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class CorporateOfficeView : BaseView
  {
    public IEnumerable<CorporateOffice> Items { get; set; }
    public ICollection<CompanyType> CompanyTypes { get; set; }
    public ICollection<Currency> Currencies { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Location> Locations { get; set; }
  }
}
