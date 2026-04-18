using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.Platform.Core.Seeding;

/// <summary>
/// Discovers all registered <see cref="IDataSeeder"/> implementations and executes them in order.
/// </summary>
public interface IDataSeedRunner
{
    Task RunAsync(CancellationToken cancellationToken = default);
}
