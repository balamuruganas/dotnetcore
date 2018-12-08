using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface IBankInfoService : IService<BankInfo>
  {
    BankInfoView GetModel();
    void Add(BankInfo bankInfo);
    void Edit(BankInfo bankInfo);
    void Remove(int id);
  }
}
