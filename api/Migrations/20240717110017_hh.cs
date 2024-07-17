using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b81d5449-7679-440e-9b15-494c8d80ac64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf3ef01f-e560-4cb1-89e0-26a2052f2f76");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43bbcc96-b215-44f7-9093-5aefcf171b47", null, "User", "USER" },
                    { "98ef5b78-9c42-4e30-b052-0e6b7f62e0ac", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43bbcc96-b215-44f7-9093-5aefcf171b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98ef5b78-9c42-4e30-b052-0e6b7f62e0ac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b81d5449-7679-440e-9b15-494c8d80ac64", null, "User", "USER" },
                    { "cf3ef01f-e560-4cb1-89e0-26a2052f2f76", null, "Admin", "ADMIN" }
                });
        }
    }
}
