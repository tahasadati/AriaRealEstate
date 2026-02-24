using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AriaRealState.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsImmediateVillaAndLand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImmediate",
                table: "Villas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsImmediate",
                table: "Lands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImmediate",
                table: "Villas");

            migrationBuilder.DropColumn(
                name: "IsImmediate",
                table: "Lands");
        }
    }
}
