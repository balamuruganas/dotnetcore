﻿using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface ITaxService : IService<Tax>
  {
    TaxView GetModel();
    void Add(Tax tax);
    void Edit(Tax tax);
    void Remove(int Id);
  }
}
