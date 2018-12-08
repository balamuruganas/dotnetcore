using Microsoft.EntityFrameworkCore;
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

    public void Add(Product prd)
    {
      _productRepository.TCMSDb.Products.Add(prd);
      _productRepository.TCMSDb.SaveChanges();
    }

    public void Edit(Product prd)
    {
      _productRepository.TCMSDb.Products.Update(prd);
      _productRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int id)
    {
      _productRepository.TCMSDb.Products.Remove(
        _productRepository.TCMSDb.Products.Include("RestrictedPorts").Include("CleaningMethods").Single(x => x.ProdID == id));
      _productRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<Product> _productRepository;
  }
}
