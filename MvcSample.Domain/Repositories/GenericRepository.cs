using System.Collections.Generic;
using System.Threading.Tasks;
using MvcSample.Domain.Contracts.Repositories;
using NHibernate;

namespace MvcSample.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ISession _session;
        public GenericRepository(ISession session)
        {
            _session = session;
        }

        protected ISession Session
        {
            get { return _session; }
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Task.Run(() => _session.Get<T>(id));
        }

        public virtual async Task<IList<T>> GetAll()
        {
            return await Task.Run(() => _session.QueryOver<T>().List<T>());
        }

        public virtual async Task Create(T entity)
        {
            await Task.Run(() => _session.Save(entity));
        }

        public virtual async Task Update(T entity)
        {
            await Task.Run(() => _session.Merge(entity));
        }

        public virtual async Task Delete(int id)
        {
            var e = await GetById(id);
            await Task.Run(() => _session.Delete(e));
        }
    }
}