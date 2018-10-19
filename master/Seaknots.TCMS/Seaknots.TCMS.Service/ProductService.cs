using Seaknots.TCMS.Core.Abstractions.Trackable;
using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;

namespace Seaknots.TCMS.Service
{
  public class ProductService : Service<Product>, IProductService
  {
    public ProductService(ITrackableRepository<Product> repository) : base(repository)
    {
    }
  }
}
