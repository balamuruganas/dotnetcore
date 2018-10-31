using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;
using Seaknots.TCMS.Entities.ViewModels;
using System;

namespace Seaknots.TCMS.Service
{
  public class LocationService : Service<Location>, ILocationService
  {
    public LocationService(MasterRepository<Location> repository) : base(repository)
    {
      _locationRepository = repository;
    }

    public LocationView GetModel()
    {
      var model = new LocationView();
      model.Title = "Location View";
      try
      {
        model.Countries = _locationRepository.TCMSDb.Countries.ToList();
        model.Regions = _locationRepository.TCMSDb.Regions.ToList();
        model.Items = _locationRepository.TCMSDb.Locations.ToList();
        return model;
      }
      catch (Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<Location> _locationRepository;
  }
}
