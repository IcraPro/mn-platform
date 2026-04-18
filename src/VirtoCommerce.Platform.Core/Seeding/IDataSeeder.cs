using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.Platform.Core.Seeding;

/// <summary>
/// Implemented by classes that seed initial or idempotent data into a specific context.
/// Seeders are discovered and executed in ascending <see cref="Order"/> by <see cref="IDataSeedRunner"/>.
/// </summary>
public interface IDataSeeder
{
    /// <summary>Execution order; lower values run first.</summary>
    int Order { get; }

    Task SeedAsync(CancellationToken cancellationToken = default);
}
