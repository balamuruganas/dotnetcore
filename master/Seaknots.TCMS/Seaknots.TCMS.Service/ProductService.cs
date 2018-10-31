using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class ProductService : Service<Product>, IProductService
  {
    public ProductService(MasterRepository<Product> repository) : base(repository)
    {
      _productRepository = repository;
    }

    public ProductView GetModel()
    {
      var model = new ProductView();
      try
      {
        model.Title = "Product View";
        model.Items = _productRepository.TCMSDb.Products;
        model.ProductCodes = _productRepository.TCMSDb.ProductCodes.ToList();
        model.ProductGroups = _productRepository.TCMSDb.ProductGroups.ToList();
        model.ProductStatus = _productRepository.TCMSDb.Status.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<Product> _productRepository;
  }
}
