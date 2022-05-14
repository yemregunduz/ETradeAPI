using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T>
        where T : BaseEntity
    {
        private readonly ETradeAPIDbContext _context;
        public WriteRepository(ETradeAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            await SaveChangesAsync();
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }
        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            SaveChanges();
            return entityEntry.State == EntityState.Detached;
        }
        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }
        public async Task<bool> Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            await SaveChangesAsync();
            return entityEntry.State==EntityState.Modified;
        }
        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public int SaveChanges()
            => _context.SaveChanges();
    }
}
