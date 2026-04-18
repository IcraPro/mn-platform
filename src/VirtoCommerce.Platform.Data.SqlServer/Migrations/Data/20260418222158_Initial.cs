using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtoCommerce.Platform.Data.SqlServer.Migrations.Data
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlatformDynamicProperty",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ValueType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsArray = table.Column<bool>(type: "bit", nullable: false),
                    IsDictionary = table.Column<bool>(type: "bit", nullable: false),
                    IsMultilingual = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDynamicProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformLocalizedItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformLocalizedItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformOperationLog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ObjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OperationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformOperationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformSetting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ObjectId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawLicense",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawLicense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDynamicPropertyDictionaryItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PropertyId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDynamicPropertyDictionaryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformDynamicPropertyDictionaryItem_PlatformDynamicProperty_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PlatformDynamicProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDynamicPropertyName",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PropertyId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDynamicPropertyName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformDynamicPropertyName_PlatformDynamicProperty_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PlatformDynamicProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformSettingValue",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ValueType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ShortTextValue = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    LongTextValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    IntegerValue = table.Column<int>(type: "int", nullable: false),
                    BooleanValue = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SettingId = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformSettingValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformSettingValue_PlatformSetting_SettingId",
                        column: x => x.SettingId,
                        principalTable: "PlatformSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformDynamicPropertyDictionaryItemName",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DictionaryItemId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Locale = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformDynamicPropertyDictionaryItemName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformDynamicPropertyDictionaryItemName_PlatformDynamicPropertyDictionaryItem_DictionaryItemId",
                        column: x => x.DictionaryItemId,
                        principalTable: "PlatformDynamicPropertyDictionaryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDynamicProperty_ObjectType_Name",
                table: "PlatformDynamicProperty",
                columns: new[] { "ObjectType", "Name" },
                unique: true,
                filter: "[ObjectType] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDynamicPropertyDictionaryItem_PropertyId_Name",
                table: "PlatformDynamicPropertyDictionaryItem",
                columns: new[] { "PropertyId", "Name" },
                unique: true,
                filter: "[PropertyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDynamicPropertyDictionaryItemName_DictionaryItemId_Locale_Name",
                table: "PlatformDynamicPropertyDictionaryItemName",
                columns: new[] { "DictionaryItemId", "Locale", "Name" },
                unique: true,
                filter: "[DictionaryItemId] IS NOT NULL AND [Locale] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformDynamicPropertyName_PropertyId_Locale_Name",
                table: "PlatformDynamicPropertyName",
                columns: new[] { "PropertyId", "Locale", "Name" },
                unique: true,
                filter: "[PropertyId] IS NOT NULL AND [Locale] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformLocalizedItem_Name_Alias",
                table: "PlatformLocalizedItem",
                columns: new[] { "Name", "Alias" });

            migrationBuilder.CreateIndex(
                name: "IX_OperationLog_ObjectType_ObjectId",
                table: "PlatformOperationLog",
                columns: new[] { "ObjectType", "ObjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectType_ObjectId",
                table: "PlatformSetting",
                columns: new[] { "ObjectType", "ObjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformSettingValue_SettingId",
                table: "PlatformSettingValue",
                column: "SettingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformDynamicPropertyDictionaryItemName");

            migrationBuilder.DropTable(
                name: "PlatformDynamicPropertyName");

            migrationBuilder.DropTable(
                name: "PlatformLocalizedItem");

            migrationBuilder.DropTable(
                name: "PlatformOperationLog");

            migrationBuilder.DropTable(
                name: "PlatformSettingValue");

            migrationBuilder.DropTable(
                name: "RawLicense");

            migrationBuilder.DropTable(
                name: "PlatformDynamicPropertyDictionaryItem");

            migrationBuilder.DropTable(
                name: "PlatformSetting");

            migrationBuilder.DropTable(
                name: "PlatformDynamicProperty");
        }
    }
}
