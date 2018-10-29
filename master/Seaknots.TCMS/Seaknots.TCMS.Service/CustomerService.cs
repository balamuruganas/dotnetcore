using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class CustomerService : Service<Customer>, ICustomerService
  {
    public CustomerService(MasterRepository<Customer> repository) : base(repository)
    {
      _customerRepository = repository;
    }

    public IQueryable<Customer> Customers => _customerRepository.TCMSDb.Customers;

    public override void Insert(Customer customer)
    {
      if(!Customers.Contains(customer))
        _customerRepository.Insert(customer);
    }

    public override void Update(Customer customer)
    {
      if (Customers.Contains(customer))
        _customerRepository.Update(customer);
    }

    public override void Delete(Customer customer)
    {
      if (Customers.Contains(customer))
        _customerRepository.Update(customer);
    }

    private MasterRepository<Customer> _customerRepository;
  }
}
