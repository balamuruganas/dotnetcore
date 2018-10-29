using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TankOperatorService : Service<TankOperator>, ITankOperatorService
  {
    public TankOperatorService(MasterRepository<TankOperator> repository) : base(repository)
    {
      _tankOperatorRepository = repository;
    }

    public IQueryable<TankOperator> TankOperators => _tankOperatorRepository.TCMSDb.TankOperators;

    public override void Insert(TankOperator to)
    {
      if(!TankOperators.Contains(to))
        _tankOperatorRepository.Insert(to);
    }

    public override void Update(TankOperator to)
    {
      if (TankOperators.Contains(to))
        _tankOperatorRepository.Update(to);
    }

    public override void Delete(TankOperator to)
    {
      if (TankOperators.Contains(to))
        _tankOperatorRepository.Update(to);
    }

    private MasterRepository<TankOperator> _tankOperatorRepository;
  }
}
