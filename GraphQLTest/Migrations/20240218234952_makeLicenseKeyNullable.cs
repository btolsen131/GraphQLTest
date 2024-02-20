using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLTest.Migrations
{
    /// <inheritdoc />
    public partial class makeLicenseKeyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_platforms",
                table: "platforms");

            migrationBuilder.RenameTable(
                name: "platforms",
                newName: "Platforms");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseKey",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms");

            migrationBuilder.RenameTable(
                name: "Platforms",
                newName: "platforms");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseKey",
                table: "platforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_platforms",
                table: "platforms",
                column: "Id");
        }
    }
}
