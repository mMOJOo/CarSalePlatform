using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSalePlatform.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhotoFileFromDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Cars",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
