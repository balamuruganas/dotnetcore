using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TaxService : Service<Tax>, ITaxService
  {
    public TaxService(MasterRepository<Tax> repository) : base(repository)
    {
      _taxRepository = repository;
    }

    public IQueryable<Tax> Taxes => _taxRepository.TCMSDb.Taxes;

    public override void Insert(Tax tax)
    {
      if(!Taxes.Contains(tax))
        _taxRepository.Insert(tax);
    }

    public override void Update(Tax tax)
    {
      if (Taxes.Contains(tax))
        _taxRepository.Update(tax);
    }

    public override void Delete(Tax tax)
    {
      if (Taxes.Contains(tax))
        _taxRepository.Update(tax);
    }

    private MasterRepository<Tax> _taxRepository;
  }
}
