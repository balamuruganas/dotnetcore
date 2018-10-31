using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;
using Seaknots.TCMS.Entities.ViewModels;
using System;
using Seaknots.TCMS.Core.Logging;

namespace Seaknots.TCMS.Service
{
  public class LocationService : EntityService<Location>, ILocationService
  {
    public LocationService(IMasterRepository<Location> repository) : base(repository)
    {
      _locationRepository = repository;
    }

    public LocationView GetModel()
    {
      var model = new LocationView { Title = "Location View" };
      try
      {
        model.Countries = _locationRepository.TCMSDb.Countries.ToList();
        model.Regions = _locationRepository.TCMSDb.Regions.ToList();
        model.Items = _locationRepository.TCMSDb.Locations.ToList();
        return model;
      }
      catch (Exception ex)
      {
        _logger.Log(ex.Message, "In VenderService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<Location> _locationRepository;
  }
}
