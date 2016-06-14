using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcSample.Domain.Contracts.Repositories;
using MvcSample.Domain.Entities;

namespace MvcSample.Domain.Repositories
{
    /// <summary>
    /// This is a sample repository for the Contacts and meant to be used when the database has not been set up.
    /// </summary>
    /// <seealso cref="MvcSample.Domain.Contracts.Repositories.IContactRepository" />
    public class ContactRepository : IContactRepository
    {
        private static readonly IList<Contact> ContactsDataSource;

        static ContactRepository()
        {
            ContactsDataSource = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Name = "Rahul Khera",
                    Mobile = "0434466499"
                }
            };
        }

        public async Task<Contact> GetById(int id)
        {
            return await Task.FromResult(ContactsDataSource.FirstOrDefault(item => item.Id == id));
        }

        public async Task<IList<Contact>> GetAll()
        {
            return await Task.FromResult(ContactsDataSource);
        }

        public async Task Create(Contact entity)
        {
            entity.Id = ContactsDataSource.Count > 0 ? ContactsDataSource.Max(item => item.Id) + 1 : 1;

            ContactsDataSource.Add(entity);
        }

        public async Task Update(Contact entity)
        {
            await Delete(entity.Id);
            ContactsDataSource.Add(entity);
        }

        public async Task Delete(int id)
        {
            var dbObject = ContactsDataSource.First(item => item.Id == id);

            if (dbObject != null)
                ContactsDataSource.Remove(dbObject);
        }
    }
}