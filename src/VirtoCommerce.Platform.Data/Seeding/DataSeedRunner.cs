using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VirtoCommerce.Platform.Core.Seeding;

namespace VirtoCommerce.Platform.Data.Seeding;

public sealed class DataSeedRunner(
    IEnumerable<IDataSeeder> seeders,
    ILogger<DataSeedRunner> logger) : IDataSeedRunner
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        foreach (var seeder in seeders.OrderBy(s => s.Order))
        {
            logger.LogInformation("Running data seeder {SeederType}", seeder.GetType().Name);
            await seeder.SeedAsync(cancellationToken);
            logger.LogInformation("Data seeder {SeederType} completed", seeder.GetType().Name);
        }
    }
}
