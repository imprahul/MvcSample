using System;
using Castle.Core;
using MvcSample.Domain.Contracts.Repositories;
using MvcSample.Domain.Contracts.UnitOfWork;
using MvcSample.Domain.Entities;
using MvcSample.Domain.Repositories;
using NHibernate;

//TODO: Comment out the following class if using the database
namespace MvcSample.Domain.UnitOfWork
{
    [CastleComponent(typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        private IContactRepository _contactRepository;
        public IContactRepository ContactRepository
        {
            get { return _contactRepository ?? (_contactRepository = new ContactRepository()); }
        }
    }
}