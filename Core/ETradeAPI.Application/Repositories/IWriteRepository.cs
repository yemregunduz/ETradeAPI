﻿using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T>
        where T: BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<T> entities);
        Task<bool> Update(T entity);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
