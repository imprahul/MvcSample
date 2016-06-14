using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvcSample.Domain.Entities;

namespace MvcSample.BusinessServices.Contracts
{
    public interface IContactsService
    {
        Task<IList<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(int id, Contact contact);
        Task DeleteContact(int id);
    }
}