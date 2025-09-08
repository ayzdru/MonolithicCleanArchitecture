
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Web.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Web.IoC
{
    public static class ConfigureServicesDependencyInjection
    {
        public static IServiceCollection AddWeb(this IServiceCollection services, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            return services;
        }
    }
}
