using ETradeAPI.Application.Wrappers.Paging;
using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T>
        where T: BaseEntity
    {
        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null,
                                                            Func<IQueryable<T>,
                                                                IOrderedQueryable<T>> orderBy = null,
                                                            Func<IQueryable<T>, IIncludableQueryable<T,
                                                                object>> include = null,
                                                            int index = 0, int size = 10,
                                                            bool enableTracking = true,
                                                            CancellationToken cancellationToken = default);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> filter, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
