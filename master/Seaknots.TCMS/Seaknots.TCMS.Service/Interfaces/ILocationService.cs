using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public interface ILocationService : IService<Location>
  {
    LocationView GetModel();
    void Add(Location loc);
    void Edit(Location loc);
    void Remove(int Id);
  }
}
