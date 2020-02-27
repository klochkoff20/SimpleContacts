using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using SimpleContacts.Infrastructure.APIResponce;

namespace SimpleContacts.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<PagedList<TEntity>> GetAllAsync(int page, int pageSize);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetAsync(object id);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task RemoveAsync(object id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Find(Guid id);
        Task<TEntity> FindAsync(Guid id);
    }
}
