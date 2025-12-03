using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudyPlusBack.Migrations
{
    /// <inheritdoc />
    public partial class FixSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a671c03-7dd5-4df1-8ca8-679284d2b3db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f86c270-0c74-4490-9705-0a19cd883120");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b5cd548-da95-4f03-8cce-9951096dce61", null, "Admin", "ADMIN" },
                    { "3c18f441-e638-41e0-b422-7d2b11c1d8b0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5cd548-da95-4f03-8cce-9951096dce61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c18f441-e638-41e0-b422-7d2b11c1d8b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a671c03-7dd5-4df1-8ca8-679284d2b3db", null, "User", "USER" },
                    { "1f86c270-0c74-4490-9705-0a19cd883120", null, "Admin", "ADMIN" }
                });
        }
    }
}
