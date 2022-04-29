
using ETradeAPI.Application.Repositories;
using ETradeAPI.Application.Wrappers.Paging;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T>
        where T : BaseEntity
    {
        private readonly ETradeAPIDbContext _context;

        public ReadRepository(ETradeAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IQueryable<T>> GetAll(bool tracking = true)
            => !tracking ? Table.AsQueryable().AsNoTracking():Table.AsQueryable();
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
            => !tracking ? Table.Where(filter).AsTracking() : Table.Where(filter);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
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
