using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface IVendorService : IService<Vendor>
  {
    VendorView GetModel();
    void Add(Vendor vendor);
    void Edit(Vendor vendor);
    void Remove(int Id);
  }
}
