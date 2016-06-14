using System;
using Castle.Core;
using MvcSample.Domain.Contracts.Repositories;
using MvcSample.Domain.Contracts.UnitOfWork;
using MvcSample.Domain.Entities;
using MvcSample.Domain.Repositories;
using NHibernate;

//TODO: Uncomment the class below if using database
namespace MvcSample.Domain.UnitOfWork
{
    //[CastleComponent(typeof(IUnitOfWork))]
    //public class UnitOfWork : IUnitOfWork, IDisposable
    //{
    //    private readonly ISessionFactory _sessionFactory;

    //    public UnitOfWork(ISessionFactory sessionFactory)
    //    {
    //        _sessionFactory = sessionFactory;
    //    }

    //    private ISession _session;
    //    private ISession Session
    //    {
    //        get
    //        {
    //            if (_session == null)
    //            {
    //                _session = _sessionFactory.OpenSession();

    //                _session.BeginTransaction();

    //                _session.FlushMode = FlushMode.Commit;
    //            }

    //            return _session;
    //        }
    //    }

    //    private IGenericRepository<Contact> _contactRepository;
    //    public IGenericRepository<Contact> ContactRepository
    //    {
    //        get { return _contactRepository ?? (_contactRepository = new GenericRepository<Contact>(Session)); }
    //    }


    //    private bool _disposed;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!_disposed && _session != null)
    //        {
    //            if (disposing)
    //            {
    //                //Automatic commit
    //                if (Session.Transaction.IsActive && !Session.Transaction.WasCommitted && !Session.Transaction.WasRolledBack)
    //                    Session.Transaction.Commit();

    //                Session.Close();
    //                _sessionFactory.Dispose();
    //            }
    //        }
    //        _disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
}