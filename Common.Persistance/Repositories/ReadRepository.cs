using Common.Application.Wrappers.Paging;
using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Common.Application.Repositories
{
    public class ReadRepository<TEntity,TContext> : IReadRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public ReadRepository(TContext context)
        {
            Context = context;
        }

        public DbSet<TEntity> Table => Context.Set<TEntity>();

        public async Task<IQueryable<TEntity>> GetAll(bool tracking = true)
            => !tracking ? Table.AsQueryable().AsNoTracking():Table.AsQueryable();
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true)
            => !tracking ? Table.Where(filter).AsTracking() : Table.Where(filter);

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var query = Table.AsQueryable();
            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }
            if(include != null)
            {
                query = include(query);
            }
            if (predicate != null )
            {
                query = query.Where(predicate);
            }
            if(orderBy != null)
            {
                return await orderBy(query).ToPaginateAsync(index,size,0,cancellationToken);
            }
            return await query.ToPaginateAsync(index, size, 0, cancellationToken);
        }


    }
}
