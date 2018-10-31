using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;

namespace Seaknots.TCMS.Service
{
  public class TaxService : EntityService<Tax>, ITaxService
  {
    public TaxService(IMasterRepository<Tax> repository) : base(repository)
    {
      _taxRepository = repository;
    }

    public TaxView GetModel()
    {
      var model = new TaxView() { Title = "Tax View" };
      try
      {
        model.Items = _taxRepository.TCMSDb.Taxes;
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In TaxService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<Tax> _taxRepository;
  }
}
