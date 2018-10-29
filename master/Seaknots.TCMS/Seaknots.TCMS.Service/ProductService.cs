using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class ProductService : Service<Product>, IProductService
  {
    public ProductService(MasterRepository<Product> repository) : base(repository)
    {
      _productRepository = repository;
    }

    public IQueryable<Product> Products => _productRepository.TCMSDb.Products;

    public override void Insert(Product product)
    {
      if(!Products.Contains(product))
        _productRepository.Insert(product);
    }

    public override void Update(Product product)
    {
      if (Products.Contains(product))
        _productRepository.Update(product);
    }

    public override void Delete(Product product)
    {
      if (Products.Contains(product))
        _productRepository.Update(product);
    }

    private MasterRepository<Product> _productRepository;
  }
}
