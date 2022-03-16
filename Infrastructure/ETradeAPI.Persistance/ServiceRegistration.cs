using Microsoft.EntityFrameworkCore;
using ETradeAPI.Persistance.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETradeAPI.Persistance.Configurations;
using ETradeAPI.Application.Repositories.CustomerRepository;
using ETradeAPI.Persistance.Repositories.CustomerRepository;
using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Persistance.Repositories.OrderRepository;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Persistance.Repositories.ProductRepository;

namespace ETradeAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETradeAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();

            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
