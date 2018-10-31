using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TankAgencyService : EntityService<TankAgency>, ITankAgencyService
  {
    public TankAgencyService(IMasterRepository<TankAgency> repository) : base(repository)
    {
      _tankAgencyRepository = repository;
    }

    public TankAgencyView GetModel()
    {
      var model = new TankAgencyView() { Title = "Tank Agency View" };
      try
      {
        model.Items = _tankAgencyRepository.TCMSDb.TankAgencies;
        model.CompanyTypes = _tankAgencyRepository.TCMSDb.CompanyTypes.ToList();
        model.Countries = _tankAgencyRepository.TCMSDb.Countries.ToList();
        model.Locations = _tankAgencyRepository.TCMSDb.Locations.ToList();
        model.Currencies = _tankAgencyRepository.TCMSDb.Currencies.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In TankAgencyService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<TankAgency> _tankAgencyRepository;
  }
}
