using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bask
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
        .Build()
        .MigrateDbContext<EFDBContext>() // <-- call it here like this.
        .Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
        public static IHost MigrateDbContext<TContext>(this IHost host) where TContext : EFDBContext
        {
            // Create a scope to get scoped services.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                // get the service provider and db context.
                var context = services.GetService<TContext>();

                // do something you can customize.
                // For example, I will migrate the database.
                SimpleData.InitData(context);
            }
            return host;
        }
    }

}
