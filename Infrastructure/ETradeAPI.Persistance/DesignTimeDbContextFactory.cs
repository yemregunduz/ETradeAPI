﻿using ETradeAPI.Persistance.Configurations;
using ETradeAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETradeAPIDbContext>
    {
        public ETradeAPIDbContext CreateDbContext(string[] args)
        {
           
            DbContextOptionsBuilder<ETradeAPIDbContext> dbContextOptionsBuilder = new ();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new ETradeAPIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
