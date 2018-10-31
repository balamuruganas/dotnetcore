using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class TankOperatorService : Service<TankOperator>, ITankOperatorService
  {
    public TankOperatorService(MasterRepository<TankOperator> repository) : base(repository)
    {
      _tankOperatorRepository = repository;
    }

    public TankOperatorView GetModel()
    {
      var model = new TankOperatorView();
      try
      {
        model.Title = "Tank Operator View";
        model.Items = _tankOperatorRepository.TCMSDb.TankOperators;
        model.OperatorTypes = _tankOperatorRepository.TCMSDb.TanksOperatorTypes.ToList();
        model.CompanyTypes = _tankOperatorRepository.TCMSDb.CompanyTypes.ToList();
        model.Countries = _tankOperatorRepository.TCMSDb.Countries.ToList();
        model.Currencies = _tankOperatorRepository.TCMSDb.Currencies.ToList();
        model.Depots = _tankOperatorRepository.TCMSDb.Depots.ToList();
        model.Locations = _tankOperatorRepository.TCMSDb.Locations.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<TankOperator> _tankOperatorRepository;
  }
}
