using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class VendorService : Service<Vendor>, IVendorService
  {
    public VendorService(MasterRepository<Vendor> repository) : base(repository)
    {
      _vendorRepository = repository;
    }

    public IQueryable<Vendor> Vendors => _vendorRepository.TCMSDb.Vendors;

    public override void Insert(Vendor vendor)
    {
      if(!Vendors.Contains(vendor))
        _vendorRepository.Insert(vendor);
    }

    public override void Update(Vendor vendor)
    {
      if (Vendors.Contains(vendor))
        _vendorRepository.Update(vendor);
    }

    public override void Delete(Vendor vendor)
    {
      if (Vendors.Contains(vendor))
        _vendorRepository.Update(vendor);
    }

    private MasterRepository<Vendor> _vendorRepository;
  }
}
