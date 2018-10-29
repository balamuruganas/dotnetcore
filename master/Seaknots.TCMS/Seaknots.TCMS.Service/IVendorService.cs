using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public interface IVendorService : IService<Vendor>
  {
    IQueryable<Vendor> Vendors { get; }
  }
}
