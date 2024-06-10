using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MBBE.Migrations
{
    /// <inheritdoc />
    public partial class removeredundantphonefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "0ee25118-0da1-4f67-9f72-014e9997da83");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cdef0cd5-24b0-4870-a7b7-320031828dc0");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e093c85-dd95-4d5d-994c-577f87a5200f", null, "Admin", "ADMIN" },
                    { "5ed07a19-651a-4fef-b489-98f1a69adae8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3e093c85-dd95-4d5d-994c-577f87a5200f");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5ed07a19-651a-4fef-b489-98f1a69adae8");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ee25118-0da1-4f67-9f72-014e9997da83", null, "User", "USER" },
                    { "cdef0cd5-24b0-4870-a7b7-320031828dc0", null, "Admin", "ADMIN" }
                });
        }
    }
}
