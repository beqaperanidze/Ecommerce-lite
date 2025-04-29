using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceLite.Migrations
{
    /// <inheritdoc />
    public partial class FixedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Dgci3gF3OxwhnA3wY3F93eN9ZMn8aZlG28RQJ1z6gM0wGHPtObL9G");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$tsJWVd12Dy5uweUWzhvZj.6uVxjGyTbQP9gieY/WLZQiGcLKYIBYK");
        }
    }
}
