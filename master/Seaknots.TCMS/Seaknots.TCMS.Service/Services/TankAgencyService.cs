﻿using Microsoft.EntityFrameworkCore;
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

    public void Add(TankAgency ta)
    {
      _tankAgencyRepository.TCMSDb.TankAgencies.Add(ta);
      _tankAgencyRepository.TCMSDb.SaveChanges();
    }

    public void Edit(TankAgency ta)
    {
      _tankAgencyRepository.TCMSDb.TankAgencies.Update(ta);
      _tankAgencyRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int id)
    {
      _tankAgencyRepository.TCMSDb.TankAgencies.Remove(
        _tankAgencyRepository.TCMSDb.TankAgencies.Include("Operators").Include("Contacts").Single(x => x.TaID == id));
      _tankAgencyRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<TankAgency> _tankAgencyRepository;
  }
}
