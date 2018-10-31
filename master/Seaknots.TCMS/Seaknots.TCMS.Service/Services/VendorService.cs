using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class VendorService : Service<Vendor>, IVendorService
  {
    public VendorService(MasterRepository<Vendor> repository) : base(repository)
    {
      _vendorRepository = repository;
    }

    public VendorView GetModel()
    {
      var model = new VendorView();
      try
      {
        model.Title = "Vendor View";
        model.Items = _vendorRepository.TCMSDb.Vendors;
        model.Countries = _vendorRepository.TCMSDb.Countries.ToList();
        model.Credentials = _vendorRepository.TCMSDb.Credentials.ToList();
        model.Credits = _vendorRepository.TCMSDb.Credits.ToList();
        model.Locations = _vendorRepository.TCMSDb.Locations.ToList();
        model.Status = _vendorRepository.TCMSDb.Status.ToList();
        model.TankAgencies = _vendorRepository.TCMSDb.TankAgencies.ToList();
        model.VendorTypes = _vendorRepository.TCMSDb.VenodrTypes.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<Vendor> _vendorRepository;
  }
}
