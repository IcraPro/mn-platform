using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtoCommerce.Platform.Data.SqlServer.Migrations.Data
{
    public partial class UpdatePlatformV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Registers the EF6 initial migration record into the EF Core history table so that
            // subsequent migrations run correctly on databases upgraded from platform v2.
            // Fresh EF Core installations do not have '__MigrationHistory', so this entire block
            // is a no-op for them — the IF EXISTS guard is the only unavoidable SQL here.
            // SQL Server does not guarantee short-circuit evaluation of AND in IF conditions,
            // so nested IF statements are required to avoid querying __MigrationHistory when
            // the table does not exist (fresh EF Core installations).
            migrationBuilder.Sql("""
                IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '__MigrationHistory')
                    IF EXISTS (SELECT 1 FROM [__MigrationHistory] WHERE ContextKey = 'VirtoCommerce.Platform.Data.Repositories.Migrations.Configuration')
                    BEGIN
                        INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
                        VALUES ('20180411091908_InitialPlatform', '2.2.3-servicing-35854')

                        ALTER TABLE [PlatformSetting] DROP COLUMN [IsSystem]
                        ALTER TABLE [PlatformSetting] DROP COLUMN [SettingValueType]
                        ALTER TABLE [PlatformSetting] DROP COLUMN [IsEnum]
                        ALTER TABLE [PlatformSetting] DROP COLUMN [IsMultiValue]
                        ALTER TABLE [PlatformSetting] DROP COLUMN [IsLocaleDependant]
                    END
                """);

            // NOTE: The ObjectType normalisation (removing the 'Entity' suffix from PlatformOperationLog)
            // that was previously in this migration has been moved to PlatformDataSeeder.
            // Data mutations belong in seeders, not in schema migrations.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
