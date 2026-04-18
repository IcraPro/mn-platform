namespace VirtoCommerce.Platform.Security.Seeding;

public sealed class SecuritySeedOptions
{
    public AdminUserSeedOptions AdminUser { get; set; }
}

public sealed class AdminUserSeedOptions
{
    /// <summary>
    /// Kept fixed to preserve compatibility with databases seeded before this seeder was introduced.
    /// Override in appsettings only for brand-new installations where a different ID is required.
    /// </summary>
    public string Id { get; set; } = "1eb2fa8ac6574541afdb525833dadb46";

    public string UserName { get; set; } = "admin";
    public string Email { get; set; } = "admin@virtocommerce.com";

    /// <summary>
    /// Default password. PasswordExpired is set to true so the user is forced to change it on first login.
    /// Should be overridden via environment variables or secrets in non-development environments.
    /// </summary>
    public string Password { get; set; } = "Store1!!";
}
