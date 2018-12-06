using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Seaknots.TCMS.Service
{
  public class CorporateOfficeService : EntityService<CorporateOffice>, ICorporateOfficeService
  {
    public CorporateOfficeService(IMasterRepository<CorporateOffice> repository) : base(repository)
    {
      _corporateOfficeRepository = repository;
    }

    public CorporateOfficeView GetModel()
    {
      var model = new CorporateOfficeView() { Title = "Corporate Office View" };
      try
      {
        model.Items = _corporateOfficeRepository.TCMSDb.CorporateOffices.Include(x => x.BankInfo).Include(x => x.Contacts);
        model.Locations = _corporateOfficeRepository.TCMSDb.Locations.ToList();
        model.CompanyTypes = _corporateOfficeRepository.TCMSDb.CompanyTypes.ToList();
        model.Countries = _corporateOfficeRepository.TCMSDb.Countries.ToList();
        model.Currencies = _corporateOfficeRepository.TCMSDb.Currencies.ToList();
        return model;
      }
      catch (Exception ex)
      {
        _logger.Log(ex.Message, "In VenderService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    public void Add(CorporateOffice coObj)
    {
      _corporateOfficeRepository.TCMSDb.CorporateOffices.Add(coObj);
      _corporateOfficeRepository.TCMSDb.SaveChanges();
    }

    public void Update(CorporateOffice coObj)
    {
      _corporateOfficeRepository.TCMSDb.CorporateOffices.Add(coObj);
      _corporateOfficeRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<CorporateOffice> _corporateOfficeRepository;
  }
}