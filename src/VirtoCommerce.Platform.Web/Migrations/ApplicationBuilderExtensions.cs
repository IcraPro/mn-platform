using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Seeding;
using VirtoCommerce.Platform.Data.Extensions;
using VirtoCommerce.Platform.Data.Repositories;
using VirtoCommerce.Platform.Security.Repositories;

namespace VirtoCommerce.Platform.Web.Migrations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePlatformMigrations(this IApplicationBuilder appBuilder, IConfiguration configuration)
        {
            var databaseProvider = configuration.GetValue("DatabaseProvider", "SqlServer");

            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var platformDbContext = serviceScope.ServiceProvider.GetRequiredService<PlatformDbContext>();
                if (databaseProvider == "SqlServer")
                    platformDbContext.Database.MigrateIfNotApplied(MigrationName.GetUpdateV2MigrationName("Platform"));
                platformDbContext.Database.Migrate();

                var securityDbContext = serviceScope.ServiceProvider.GetRequiredService<SecurityDbContext>();
                if (databaseProvider == "SqlServer")
                    securityDbContext.Database.MigrateIfNotApplied(MigrationName.GetUpdateV2MigrationName("Security"));
                securityDbContext.Database.Migrate();
            }

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
