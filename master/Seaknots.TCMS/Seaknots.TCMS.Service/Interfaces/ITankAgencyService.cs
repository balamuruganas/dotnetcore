using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface ITankAgencyService : IService<TankAgency>
  {
    TankAgencyView GetModel();
    void Add(TankAgency ta);
    void Edit(TankAgency ta);
    void Remove(int Id);
  }
}
