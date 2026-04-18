using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtoCommerce.Platform.Core.Seeding;
using VirtoCommerce.Platform.Data.Repositories;
using VirtoCommerce.Platform.Security.Repositories;

namespace VirtoCommerce.Platform.Web.Migrations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePlatformMigrations(this IApplicationBuilder appBuilder)
        {
            using var serviceScope = appBuilder.ApplicationServices.CreateScope();

            serviceScope.ServiceProvider
                .GetRequiredService<PlatformDbContext>()
                .Database.Migrate();

            serviceScope.ServiceProvider
                .GetRequiredService<SecurityDbContext>()
                .Database.Migrate();

            return appBuilder;
        }

        /// <summary>
        /// Runs all registered <see cref="IDataSeeder"/> implementations in ascending order.
        /// Must be called after <see cref="UsePlatformMigrations"/> so the schema is up to date.
        /// </summary>
        public static IApplicationBuilder UsePlatformSeedData(this IApplicationBuilder appBuilder)
        {
            using var serviceScope = appBuilder.ApplicationServices.CreateScope();
            var seedRunner = serviceScope.ServiceProvider.GetRequiredService<IDataSeedRunner>();
            seedRunner.RunAsync(CancellationToken.None).GetAwaiter().GetResult();
            return appBuilder;
        }
    }
}
