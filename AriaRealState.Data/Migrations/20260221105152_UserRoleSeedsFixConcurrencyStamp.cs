using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AriaRealState.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleSeedsFixConcurrencyStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a111111-1111-1111-1111-111111111111",
                column: "ConcurrencyStamp",
                value: "role-superadmin-v1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a222222-2222-2222-2222-222222222222",
                column: "ConcurrencyStamp",
                value: "role-admin-v1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a333333-3333-3333-3333-333333333333",
                column: "ConcurrencyStamp",
                value: "role-supportlight-v1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a444444-4444-4444-4444-444444444444",
                column: "ConcurrencyStamp",
                value: "role-seo-v1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a111111-1111-1111-1111-111111111111",
                column: "ConcurrencyStamp",
                value: "3028786c-9c88-449a-9559-ed2f5a3eac4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a222222-2222-2222-2222-222222222222",
                column: "ConcurrencyStamp",
                value: "be79a1b1-ddf1-4936-800c-bf383150dd48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a333333-3333-3333-3333-333333333333",
                column: "ConcurrencyStamp",
                value: "3556b66f-02e3-434a-b351-bfd2a52426b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a444444-4444-4444-4444-444444444444",
                column: "ConcurrencyStamp",
                value: "aa24603e-ce15-4edd-bcfd-94911703b915");
        }
    }
}
