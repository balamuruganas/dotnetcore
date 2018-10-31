using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;

namespace Seaknots.TCMS.Service
{
  public class TaxService : Service<Tax>, ITaxService
  {
    public TaxService(MasterRepository<Tax> repository) : base(repository)
    {
      _taxRepository = repository;
    }

    public TaxView GetModel()
    {
      var model = new TaxView();
      try
      {
        model.Title = "Tax View";
        model.Items = _taxRepository.TCMSDb.Taxes;
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<Tax> _taxRepository;
  }
}
