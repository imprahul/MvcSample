using MvcSample.Domain.Contracts.Repositories;
using MvcSample.Domain.Entities;

namespace MvcSample.Domain.Contracts.UnitOfWork
{
    /// <summary>
    /// Unit of work interface to consolidate all the repositories
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Contact Repository that reads from an in-memory static datasource
        /// </summary>
        //TODO: Comment out this repository if using the database
        IContactRepository ContactRepository { get; }

        //TODO: Use this repository if using the database
        //IGenericRepository<Contact> ContactRepository { get; }
    }
}