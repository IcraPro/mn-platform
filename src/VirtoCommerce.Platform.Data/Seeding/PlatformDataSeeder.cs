using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VirtoCommerce.Platform.Core.Seeding;
using VirtoCommerce.Platform.Data.Repositories;

namespace VirtoCommerce.Platform.Data.Seeding;

/// <summary>
/// Handles idempotent platform-level data initialization.
/// Data mutations that previously lived inside raw SQL migrations are managed here instead.
/// </summary>
public sealed class PlatformDataSeeder(
    Func<IPlatformRepository> repositoryFactory,
    ILogger<PlatformDataSeeder> logger) : IDataSeeder
{
    public int Order => 0;

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        await NormalizeOperationLogObjectTypesAsync(cancellationToken);
    }

    /// <summary>
    /// Strips the 'Entity' suffix from ObjectType values in PlatformOperationLog.
    /// Previously done via raw SQL in the UpdatePlatformV2 migration; moved here so
    /// data mutations remain separate from schema migrations.
    /// </summary>
    private async Task NormalizeOperationLogObjectTypesAsync(CancellationToken cancellationToken)
    {
        using var repository = repositoryFactory();

        var legacyEntries = await repository.OperationLogs
            .Where(x => x.ObjectType.EndsWith("Entity"))
            .ToListAsync(cancellationToken);

        if (legacyEntries.Count == 0)
        {
            return;
        }

        logger.LogInformation(
            "Normalizing {Count} legacy ObjectType values in PlatformOperationLog",
            legacyEntries.Count);

        foreach (var entry in legacyEntries)
        {
            entry.ObjectType = entry.ObjectType[..^"Entity".Length];
        }

        await repository.UnitOfWork.CommitAsync();
    }
}
