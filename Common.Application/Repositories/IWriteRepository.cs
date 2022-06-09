using ETradeAPI.Domain.Entities.Common;

namespace Common.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
