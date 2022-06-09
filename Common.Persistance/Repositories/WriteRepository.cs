using Common.Application.Repositories;
using ETradeAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETradeAPI.Persistance.Repositories
{
    public class WriteRepository<TEntity,TContext> : IWriteRepository<TEntity>
        where TEntity : BaseEntity
        where TContext: DbContext
    {
        protected TContext Context { get; }
        public WriteRepository(TContext context)
        {
            Context = context;
        }
        public DbSet<TEntity> Table => Context.Set<TEntity>();
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return true;
        }
        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            SaveChanges();
            return entityEntry.State == EntityState.Detached;
        }
        public bool RemoveRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            TEntity model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            var entityToUpdated = Context.Entry(entity);
            foreach (var property in entityToUpdated.Properties)
            {
                if (!property.Metadata.Name.Equals("Id") && !property.Metadata.Name.Equals("CreatedDate"))
                {
                    property.IsModified = true;
                }
            }
            await SaveChangesAsync();
            return entity;
        }
        public async Task<int> SaveChangesAsync()
            => await Context.SaveChangesAsync();

        public int SaveChanges()
            => Context.SaveChanges();
    }
}
