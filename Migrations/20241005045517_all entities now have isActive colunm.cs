using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_work_backend.Migrations
{
    /// <inheritdoc />
    public partial class allentitiesnowhaveisActivecolunm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Universities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PracticeStrategys",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Approaches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Allieds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PracticeStrategys");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Approaches");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Allieds");
        }
    }
}
