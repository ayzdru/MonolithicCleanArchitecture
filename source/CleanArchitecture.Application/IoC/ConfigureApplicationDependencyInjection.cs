using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IoC
{
    public static class ConfigureApplicationDependencyInjection
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
