using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VirtoCommerce.Platform.Core.Seeding;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Platform.Security.Seeding;

/// <summary>
/// Seeds the initial administrator account using ASP.NET Core Identity APIs.
/// This replaces the raw SQL INSERT statements that previously lived inside
/// provider-specific migration files.
/// </summary>
public sealed class SecurityDataSeeder(
    UserManager<ApplicationUser> userManager,
    IOptions<SecuritySeedOptions> options,
    ILogger<SecurityDataSeeder> logger) : IDataSeeder
{
    public int Order => 10;

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var adminOpts = options.Value.AdminUser;
        if (adminOpts is null)
        {
            return;
        }

        await SeedAdminUserAsync(adminOpts);
    }

    private async Task SeedAdminUserAsync(AdminUserSeedOptions opts)
    {
        if (await userManager.FindByNameAsync(opts.UserName) is not null)
        {
            logger.LogDebug("Admin user '{UserName}' already exists — skipping seed", opts.UserName);
            return;
        }

        logger.LogInformation("Creating initial admin user '{UserName}'", opts.UserName);

        var user = new ApplicationUser
        {
            Id = opts.Id,
            UserName = opts.UserName,
            NormalizedUserName = opts.UserName.ToUpperInvariant(),
            Email = opts.Email,
            NormalizedEmail = opts.Email.ToUpperInvariant(),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            IsAdministrator = true,
            LockoutEnabled = true,
            // Force the admin to set their own password on first login.
            PasswordExpired = true,
        };

        var result = await userManager.CreateAsync(user, opts.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            logger.LogError("Failed to create admin user '{UserName}': {Errors}", opts.UserName, errors);
            throw new InvalidOperationException($"Admin user seed failed: {errors}");
        }

        logger.LogInformation("Admin user '{UserName}' created successfully", opts.UserName);
    }
}
