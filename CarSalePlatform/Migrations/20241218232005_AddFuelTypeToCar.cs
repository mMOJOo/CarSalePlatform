using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSalePlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelTypeToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "OwnerEmail",
                table: "Cars",
                newName: "FuelType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "Cars",
                newName: "OwnerEmail");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
