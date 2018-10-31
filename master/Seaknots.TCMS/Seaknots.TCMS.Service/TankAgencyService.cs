using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TankAgencyService : Service<TankAgency>, ITankAgencyService
  {
    public TankAgencyService(MasterRepository<TankAgency> repository) : base(repository)
    {
      _tankAgencyRepository = repository;
    }

    public TankAgencyView GetModel()
    {
      var model = new TankAgencyView();
      try
      {
        model.Title = "Tank Agency View";
        model.Items = _tankAgencyRepository.TCMSDb.TankAgencies;
        model.CompanyTypes = _tankAgencyRepository.TCMSDb.CompanyTypes.ToList();
        model.Countries = _tankAgencyRepository.TCMSDb.Countries.ToList();
        model.Locations = _tankAgencyRepository.TCMSDb.Locations.ToList();
        model.Currencies = _tankAgencyRepository.TCMSDb.Currencies.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<TankAgency> _tankAgencyRepository;
  }
}
