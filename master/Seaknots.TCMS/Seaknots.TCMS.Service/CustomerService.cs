using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class CustomerService : Service<Customer>, ICustomerService
  {
    public CustomerService(MasterRepository<Customer> repository) : base(repository)
    {
      _customerRepository = repository;
    }

    public CustomerView GetModel()
    {
      var model = new CustomerView();
      try
      {
        model.Title = "Customer View";
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
        return model;
      }
    }

    private MasterRepository<Customer> _customerRepository;
  }
}
