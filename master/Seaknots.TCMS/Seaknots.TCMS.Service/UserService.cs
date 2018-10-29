using Seaknots.TCMS.Core.Concrete.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Repository;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class UserService : Service<User>, IUserService
  {
    public UserService(MasterRepository<User> repository) : base(repository)
    {
      _userRepository = repository;
    }

    public IQueryable<User> Users => _userRepository.TCMSDb.Users;

    public override void Insert(User user)
    {
      if(!Users.Contains(user))
        _userRepository.Insert(user);
    }

    public override void Update(User user)
    {
      if (Users.Contains(user))
        _userRepository.Update(user);
    }

    public override void Delete(User user)
    {
      if (Users.Contains(user))
        _userRepository.Update(user);
    }

    private MasterRepository<User> _userRepository;
  }
}
