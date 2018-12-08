using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class CustomerService : EntityService<Customer>, ICustomerService
  {
    public CustomerService(IMasterRepository<Customer> repository) : base(repository)
    {
      _customerRepository = repository;
    }

    public CustomerView GetModel()
    {
      var model = new CustomerView() { Title = "Customer View" };
      try
      {
        model.Items = _customerRepository.TCMSDb.Customers;
        model.Locations = _customerRepository.TCMSDb.Locations.ToList();
        model.Status = _customerRepository.TCMSDb.Status.ToList();
        model.TankAgencies = _customerRepository.TCMSDb.TankAgencies.ToList();
        model.Credits = _customerRepository.TCMSDb.Credits.ToList();
        model.Credentials = _customerRepository.TCMSDb.Credentials.ToList();
        model.Countries = _customerRepository.TCMSDb.Countries.ToList();
        model.CustomerTypes = _customerRepository.TCMSDb.CustomerTypes.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In VenderService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    public void Add(Customer cObj)
    {
      _customerRepository.TCMSDb.Customers.Add(cObj);
      _customerRepository.TCMSDb.SaveChanges();
    }

    public void Edit(Customer cObj)
    {
      _customerRepository.TCMSDb.Customers.Update(cObj);
      _customerRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int cID)
    {
      Customer obj = _customerRepository.TCMSDb.Customers.Where(x => x.CustomerID == cID).FirstOrDefault();
      _customerRepository.TCMSDb.Customers.Remove(
        _customerRepository.TCMSDb.Customers.Include("Followups").Include("Affliates").Single(x => x.CustomerID == cID));
      _customerRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<Customer> _customerRepository;
  }
}
