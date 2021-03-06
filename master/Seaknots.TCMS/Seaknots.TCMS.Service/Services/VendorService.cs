﻿using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;
using Seaknots.TCMS.Core.Logging;
using Microsoft.EntityFrameworkCore;

namespace Seaknots.TCMS.Service
{
  public class VendorService : EntityService<Vendor>, IVendorService
  {
    public VendorService(IMasterRepository<Vendor> repository) : base(repository)
    {
      _vendorRepository = repository;
    }

    public VendorView GetModel()
    {
      var model = new VendorView() { Title = "Vendor View" };
      try
      {
        model.Items = _vendorRepository.TCMSDb.Vendors;
        model.Countries = _vendorRepository.TCMSDb.Countries.ToList();
        model.Credentials = _vendorRepository.TCMSDb.Credentials.ToList();
        model.Credits = _vendorRepository.TCMSDb.Credits.ToList();
        model.Locations = _vendorRepository.TCMSDb.Locations.ToList();
        model.Status = _vendorRepository.TCMSDb.Status.ToList();
        model.TankAgencies = _vendorRepository.TCMSDb.TankAgencies.ToList();
        model.VendorTypes = _vendorRepository.TCMSDb.VenodrTypes.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In VenderService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    public void Add(Vendor vendor)
    {
      _vendorRepository.TCMSDb.Vendors.Add(vendor);
      _vendorRepository.TCMSDb.SaveChanges();
    }

    public void Edit(Vendor vendor)
    {
      _vendorRepository.TCMSDb.Vendors.Update(vendor);
      _vendorRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int id)
    {
      _vendorRepository.TCMSDb.Vendors.Remove(_vendorRepository.TCMSDb.Vendors.Include("Contacts").Single(x => x.VendorID == id));
      _vendorRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<Vendor> _vendorRepository;
  }
}
