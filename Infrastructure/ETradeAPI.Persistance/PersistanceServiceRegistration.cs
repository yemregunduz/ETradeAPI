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
using ETradeAPI.Application.Repositories.FileRepository;
using ETradeAPI.Persistance.Repositories.FileRepository;
using ETradeAPI.Persistance.Repositories.FileRepository.InvoiceFileRepository;
using ETradeAPI.Application.Repositories.FileRepository.InvoiceFileRepository;
using ETradeAPI.Application.Repositories.FileRepository.ProductImageFileRepository;
using ETradeAPI.Persistance.Repositories.FileRepository.ProductImageFileRepository;

namespace ETradeAPI.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETradeAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();


        }
    } 
}
