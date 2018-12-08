using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface ICorporateOfficeService : IService<CorporateOffice>
  {
    CorporateOfficeView GetModel();
    void Add(CorporateOffice coObj);
    void Edit(CorporateOffice coObj);
    void Remove(int Id);
  }
}
