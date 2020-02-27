using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Infrastructure.Helpers;
using Z.EntityFramework.Plus;

namespace SimpleContacts.DAL.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Context;
        protected DbSet<TEntity> DbSet { get; }
        public IQueryable<TEntity> Entities { get; }

        public Repository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            Entities = DbSet;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<PagedList<TEntity>> GetAllAsync(int page, int pageSize)
        {
            if (page < 0 || pageSize <= 0)
            {
                var items = await GetAllAsync();
                return items.ToPagedList(1, items.Count(), items.Count());
            }

            page = Math.Max(page, 1);
            var totalCount = Context.Set<TEntity>().DeferredCount().FutureValue();
            var result = await Context.Set<TEntity>()
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Future()
                .ToListAsync();

            return result.ToPagedList(page, pageSize, totalCount);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public async Task RemoveAsync(object id)
        {
            TEntity entity = await DbSet.FindAsync(id);
            Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
