using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class CorporateOfficeService : Service<CorporateOffice>, ICorporateOfficeService
  {
    public CorporateOfficeService(MasterRepository<CorporateOffice> repository) : base(repository)
    {
      _corporateOfficeRepository = repository;
      foreach(var co in CorporateOffices)
      {
        co.CompanyTypes = _corporateOfficeRepository.TCMSDb.CompanyTypes.ToList();
        co.Countries = _corporateOfficeRepository.TCMSDb.Countries.ToList();
        co.Currencies = _corporateOfficeRepository.TCMSDb.Currencies.ToList();
        co.Locations = _corporateOfficeRepository.TCMSDb.Locations.Where(x => x.Country.Text == co.Country.Text).ToList();
      }
    }

    public IQueryable<CorporateOffice> CorporateOffices => _corporateOfficeRepository.TCMSDb.CorporateOffices;

    public override void Insert(CorporateOffice co)
    {
      if(!CorporateOffices.Contains(co))
        _corporateOfficeRepository.Insert(co);
    }

    public override void Update(CorporateOffice co)
    {
      if (CorporateOffices.Contains(co))
        _corporateOfficeRepository.Update(co);
    }

    public override void Delete(CorporateOffice co)
    {
      if (CorporateOffices.Contains(co))
        _corporateOfficeRepository.Update(co);
    }

    private MasterRepository<CorporateOffice> _corporateOfficeRepository;
  }
}
