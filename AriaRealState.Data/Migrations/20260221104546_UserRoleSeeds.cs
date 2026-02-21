using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AriaRealState.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a111111-1111-1111-1111-111111111111", "3028786c-9c88-449a-9559-ed2f5a3eac4c", "SuperAdmin", "SUPERADMIN" },
                    { "2a222222-2222-2222-2222-222222222222", "be79a1b1-ddf1-4936-800c-bf383150dd48", "Admin", "ADMIN" },
                    { "3a333333-3333-3333-3333-333333333333", "3556b66f-02e3-434a-b351-bfd2a52426b8", "SupportLight", "SUPPORTLIGHT" },
                    { "4a444444-4444-4444-4444-444444444444", "aa24603e-ce15-4edd-bcfd-94911703b915", "Seo", "SEO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a333333-3333-3333-3333-333333333333");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a444444-4444-4444-4444-444444444444");
        }
    }
}
