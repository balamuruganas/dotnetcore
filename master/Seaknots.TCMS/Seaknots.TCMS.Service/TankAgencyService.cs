using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TankAgencyService : Service<TankAgency>, ITankAgencyService
  {
    public TankAgencyService(MasterRepository<TankAgency> repository) : base(repository)
    {
      _tankAgencyRepository = repository;
    }

    public IQueryable<TankAgency> TankAgencies => _tankAgencyRepository.TCMSDb.TankAgencies;

    public override void Insert(TankAgency ta)
    {
      if(!TankAgencies.Contains(ta))
        _tankAgencyRepository.Insert(ta);
    }

    public override void Update(TankAgency ta)
    {
      if (TankAgencies.Contains(ta))
        _tankAgencyRepository.Update(ta);
    }

    public override void Delete(TankAgency ta)
    {
      if (TankAgencies.Contains(ta))
        _tankAgencyRepository.Update(ta);
    }

    private MasterRepository<TankAgency> _tankAgencyRepository;
  }
}
