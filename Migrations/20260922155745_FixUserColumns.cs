using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPWebApiManual.Migrations
{
    /// <inheritdoc />
    public partial class FixUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "hashPassword",
                table: "Users",
                newName: "HashPassword");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "hashPassword");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");
        }
    }
}
