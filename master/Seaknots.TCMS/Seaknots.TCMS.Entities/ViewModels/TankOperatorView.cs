using System.Collections.Generic;

namespace Seaknots.TCMS.Entities.ViewModels
{
  public class TankOperatorView : BaseView
  {
    public IEnumerable<TankOperator> Items { get; set; }
    public ICollection<CompanyType> CompanyTypes { get; set; }
    public ICollection<Currency> Currencies { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<OperatorType> OperatorTypes { get; set; }
    public ICollection<Port> Ports { get; set; }
    public ICollection<Depot> Depots { get; set; }
  }
}
