using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static IHost Seed(this IHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {               
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                //Seed kodları buraya
                try
                {
                    applicationDbContext.Database.Migrate();
                }
                catch
                {

                }
            }
            return host;
        }
    }
}
