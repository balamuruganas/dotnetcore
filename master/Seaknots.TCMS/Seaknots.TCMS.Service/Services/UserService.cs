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
        model.Locations = _userRepository.TCMSDb.Locations.ToList();
        return model;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    public User Login(User user)
    {
      try
      {
        return _userRepository.TCMSDb.Users.Where(x => x.Email == user.Email && x.Password == user.Password)?.FirstOrDefault();
      }
      catch (Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:Login", Logger.LogLevel.Fatal);
        return null;
      }
    }

    public User Register(User user)
    {
      try
      {
        if(_userRepository.TCMSDb.Users.Where(x => x.Email == user.Email)?.FirstOrDefault() != null)
        {
          _logger.Log(string.Format("User {0} already exists, registration failed.", user.Email), 
            "In UserService:Register", Logger.LogLevel.Error);
          return null;
        }

        _userRepository.Insert(user);
        return _userRepository.TCMSDb.Users.Where(x => x.Email == user.Email && x.Password == user.Password)?.FirstOrDefault();
      }
      catch (Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:Register", Logger.LogLevel.Fatal);
        return null;
      }
    }

    public string GetRole(string userName)
    {
      try
      {
        User user = _userRepository.TCMSDb.Users.Where(x => x.Email == userName)?.FirstOrDefault();
        if (user != null)
          return _userRepository.TCMSDb.Roles.Where(x => x.RoleID == user.RoleID)?.FirstOrDefault().Name;
      }
      catch(Exception ex)
      {
        _logger.Log(ex.Message, "In UserService:GetRole", Logger.LogLevel.Fatal);
        return string.Empty;
      }

      return string.Empty;
    }

    public void Add(User usr)
    {
      _userRepository.TCMSDb.Users.Add(usr);
      _userRepository.TCMSDb.SaveChanges();
    }

    public void Edit(User usr)
    {
      _userRepository.TCMSDb.Users.Update(usr);
      _userRepository.TCMSDb.SaveChanges();
    }

    public void Remove(int id)
    {
      _userRepository.TCMSDb.Users.Remove(_userRepository.TCMSDb.Users.Single(x => x.UserID == id));
      _userRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<User> _userRepository;
  }
}
