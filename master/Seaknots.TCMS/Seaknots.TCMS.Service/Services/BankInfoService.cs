using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class BankInfoService : EntityService<BankInfo>, IBankInfoService
  {
    public BankInfoService(IMasterRepository<BankInfo> repository) : base(repository)
    {
      _bankRepository = repository;
      CurrentService = this;
    }

    public static BankInfoService CurrentService = null;

    public BankInfoView GetModel()
    {
      var model = new BankInfoView() { Title = "Bank Info View" };
      try
      {
        model.Items = _bankRepository.TCMSDb.Banks;
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In BankInfoService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<BankInfo> _bankRepository;
  }
}
