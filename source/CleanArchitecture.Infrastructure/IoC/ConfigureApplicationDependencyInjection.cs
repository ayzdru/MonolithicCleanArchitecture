using CleanArchitecture.Application.IoC;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class ConfigureApplicationDependencyInjection
    {
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseApplication();
            return app;
        }
    }
}
