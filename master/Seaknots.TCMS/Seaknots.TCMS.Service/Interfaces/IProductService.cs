using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using System.Linq;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface IProductService : IService<Product>
  {
    ProductView GetModel();
    void Add(Product prd);
    void Edit(Product prd);
    void Remove(int Id);
  }
}
