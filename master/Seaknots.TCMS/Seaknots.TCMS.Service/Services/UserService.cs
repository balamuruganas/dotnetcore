using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class UserService : EntityService<User>, IUserService
  {
    public UserService(IMasterRepository<User> repository) : base(repository)
    {
      _userRepository = repository;
    }

    public UserView GetModel()
    {
      var model = new UserView() { Title = "User View" };
      try
      {
        model.Items = _userRepository.TCMSDb.Users;
        model.Roles = _userRepository.TCMSDb.Roles.ToList();
        model.Companies = _userRepository.TCMSDb.Companies.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    private IMasterRepository<User> _userRepository;
  }
}
