using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AriaRealState.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteNeighborhood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.AddColumn<string>(
                name: "NeighborhoodName",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeighborhoodName",
                table: "Lands",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeighborhoodName",
                table: "Villas");

            migrationBuilder.DropColumn(
                name: "NeighborhoodName",
                table: "Lands");

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeighborhoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });
        }
    }
}
