using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

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

    public void Add(Tax tax)
    {
      _taxRepository.TCMSDb.Taxes.Add(tax);
      _taxRepository.TCMSDb.SaveChanges();
    }

    public void Edit(Tax tax)
    {
      _taxRepository.TCMSDb.Taxes.Update(tax);
      _taxRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int id)
    {
      _taxRepository.TCMSDb.Taxes.Remove(_taxRepository.TCMSDb.Taxes.Single(x => x.TaxID == id));
      _taxRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<Tax> _taxRepository;
  }
}
