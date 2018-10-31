using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class ProductService : EntityService<Product>, IProductService
  {
    public ProductService(IMasterRepository<Product> repository) : base(repository)
    {
      _productRepository = repository;
    }

    public ProductView GetModel()
    {
      var model = new ProductView() { Title = "Product View" };
      try
      {
        model.Items = _productRepository.TCMSDb.Products;
        model.ProductCodes = _productRepository.TCMSDb.ProductCodes.ToList();
        model.ProductGroups = _productRepository.TCMSDb.ProductGroups.ToList();
        model.ProductStatus = _productRepository.TCMSDb.Status.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In ProductService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<Product> _productRepository;
  }
}
