using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface IUserService : IService<User>
  {
    UserView GetModel();
    void Add(User usr);
    void Edit(User usr);
    void Remove(int Id);
  }
}
