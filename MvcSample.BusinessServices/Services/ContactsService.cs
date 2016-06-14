using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.Core;
using MvcSample.BusinessServices.Contracts;
using MvcSample.Domain.Contracts.UnitOfWork;
using MvcSample.Domain.Entities;

namespace MvcSample.BusinessServices.Services
{
    [CastleComponent(typeof(IContactsService))]
    public class ContactsService : IContactsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Contact>> GetContacts()
        {
            return await _unitOfWork.ContactRepository.GetAll();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _unitOfWork.ContactRepository.GetById(id);
        }

        public async Task AddContact(Contact contact)
        {
            await _unitOfWork.ContactRepository.Create(contact);
        }

        public async Task UpdateContact(int id, Contact contact)
        {
            await _unitOfWork.ContactRepository.Update(contact);
        }

        public async Task DeleteContact(int id)
        {
            await _unitOfWork.ContactRepository.Delete(id);
        }
    }
}