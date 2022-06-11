using Common.Application.Pipelines.Authorization;
using ETradeAPI.Application.Features.Authorizations.Rules;
using ETradeAPI.Application.Features.Products.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ETradeAPI.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<AuthorizationBusinessRules>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;    
        }
    }
}
