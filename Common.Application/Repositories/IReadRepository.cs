using Common.Application.Wrappers.Paging;
using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Common.Application.Repositories
{
    public interface IReadRepository<TEntity>:IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                            Func<IQueryable<TEntity>,
                                                                IOrderedQueryable<TEntity>> orderBy = null,
                                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
                                                                object>> include = null,
                                                            int index = 0, int size = 10,
                                                            bool enableTracking = true,
                                                            CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
        Task<TEntity> GetByIdAsync(string id, bool tracking = true);

    }
}
