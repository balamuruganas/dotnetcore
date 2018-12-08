using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public interface ICustomerService : IService<Customer>
  {
    CustomerView GetModel();
    void Add(Customer cObj);
    void Edit(Customer cObj);
    void Remove(int Id);
  }
}
