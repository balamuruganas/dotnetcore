using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class LocationService : Service<Location>, ILocationService
  {
    public LocationService(MasterRepository<Location> repository) : base(repository)
    {
      _locationRepository = repository;
    }

    public IQueryable<Location> Locations => _locationRepository.TCMSDb.Locations;

    public override void Insert(Location location)
    {
      if(!Locations.Contains(location))
        _locationRepository.Insert(location);
    }

    public override void Update(Location location)
    {
      if (Locations.Contains(location))
        _locationRepository.Update(location);
    }

    public override void Delete(Location location)
    {
      if (Locations.Contains(location))
        _locationRepository.Update(location);
    }

    private MasterRepository<Location> _locationRepository;
  }
}
