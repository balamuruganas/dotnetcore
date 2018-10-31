using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class CorporateOfficeService : Service<CorporateOffice>, ICorporateOfficeService
  {
    public CorporateOfficeService(MasterRepository<CorporateOffice> repository) : base(repository)
    {
      _corporateOfficeRepository = repository;
    }

    public CorporateOfficeView GetModel()
    {
      var model = new CorporateOfficeView();
      try
      {
        model.Title = "Corporate Office View";
        model.Items = _corporateOfficeRepository.TCMSDb.CorporateOffices;
        model.Locations = _corporateOfficeRepository.TCMSDb.Locations.ToList();
        model.CompanyTypes = _corporateOfficeRepository.TCMSDb.CompanyTypes.ToList();
        model.Countries = _corporateOfficeRepository.TCMSDb.Countries.ToList();
        model.Currencies = _corporateOfficeRepository.TCMSDb.Currencies.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<CorporateOffice> _corporateOfficeRepository;
  }
}
