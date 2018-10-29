﻿using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public interface IProductService : IService<Product>
  {
    IQueryable<Product> Products { get; }
  }
}
