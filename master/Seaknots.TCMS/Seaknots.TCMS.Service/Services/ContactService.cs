using Seaknots.TCMS.Core.Logging;
using Seaknots.TCMS.Entities;
using Seaknots.TCMS.Entities.ViewModels;
using Seaknots.TCMS.Repository;
using System;
using System.Linq;

namespace Seaknots.TCMS.Service
{
  public class ContactService : EntityService<Contact>, IContactService
  {
    public ContactService(IMasterRepository<Contact> repository) : base(repository)
    {
      _contactRepository = repository;
      CurrentService = this;
    }

    public static ContactService CurrentService = null;

    public ContactView GetModel()
    {
      var model = new ContactView() { Title = "Contact View" };
      try
      {
        model.Items = _contactRepository.TCMSDb.Contacts;
        return model;
      }
      catch (Exception ex)
      {
        _logger.Log(ex.Message, "In ContactService:GetModel", Logger.LogLevel.Fatal);
        return model;
      }
    }

    public void Add(Contact contact)
    {
      _contactRepository.TCMSDb.Contacts.Add(contact);
      _contactRepository.TCMSDb.SaveChanges();
    }

    private IMasterRepository<Contact> _contactRepository;
  }
}