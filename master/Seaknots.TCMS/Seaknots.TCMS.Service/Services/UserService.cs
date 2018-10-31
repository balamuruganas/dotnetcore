using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class UserService : Service<User>, IUserService
  {
    public UserService(MasterRepository<User> repository) : base(repository)
    {
      _userRepository = repository;
    }

    public UserView GetModel()
    {
      var model = new UserView();
      try
      {
        model.Title = "User View";
        model.Items = _userRepository.TCMSDb.Users;
        model.Roles = _userRepository.TCMSDb.Roles.ToList();
        model.Companies = _userRepository.TCMSDb.Companies.ToList();
        return model;
      }
      catch(Exception ex)
      {
        return model;
      }
    }

    private MasterRepository<User> _userRepository;
  }
}
