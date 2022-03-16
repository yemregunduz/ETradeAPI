﻿using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<T> GetAll()
            => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
            => Table.Where(filter);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
            => await Table.FirstOrDefaultAsync(filter);
        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}
