using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface ITankOperatorService : IService<TankOperator>
  {
    TankOperatorView GetModel();
    void Add(TankOperator to);
    void Edit(TankOperator tp);
    void Remove(int Id);
  }
}
