using ETradeAPI.Application.Services.Storage;
using ETradeAPI.Common.Security.Jwt;
using ETradeAPI.Infrastructure.Enums;
using ETradeAPI.Infrastructure.Services.Storage;
using ETradeAPI.Infrastructure.Services.Storage.Azure;
using ETradeAPI.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace ETradeAPI.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddTransient<ITokenHelper, TokenHelper>();

        }
        public static void AddStorage<T>(this IServiceCollection services)
            where T: Storage,IStorage
        {
            services.AddScoped<IStorage, T>();
        }
        //Tercih edilmez.
        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;

            }
        }
    }
}
