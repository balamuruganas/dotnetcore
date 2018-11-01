using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.DataAccess;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Collections;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class UserService : EntityService<User>, IUserService
  {
    public UserService(IMasterRepository<User> repository) : base(repository)
    {
      _userRepository = repository;
      CurrentService = this;
    }

    public static UserService CurrentService = null;

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

    public string GetRole(string userName)
    {
      try
      {
        User user = _userRepository.TCMSDb.Users.Where(x => x.Email == userName).FirstOrDefault();
        if (user != null)
          return _userRepository.TCMSDb.Roles.Where(x => x.ID == user.RoleID).FirstOrDefault().Name;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:GetRole", Logger.LogLevel.Fatal);
        return string.Empty;
      }

      return string.Empty;
    }

    private IMasterRepository<User> _userRepository;
  }
}
