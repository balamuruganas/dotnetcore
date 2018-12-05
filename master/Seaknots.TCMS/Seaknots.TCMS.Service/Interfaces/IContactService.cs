using Seaknots.TCMS.Core.Abstractions.Service;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;

namespace Seaknots.TCMS.Service
{
  public interface IContactService : IService<Contact>
  {
    ContactView GetModel();

    void Add(Contact contact);
  }
}