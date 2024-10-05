using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_work_backend.Migrations
{
    /// <inheritdoc />
    public partial class addisActivecoluminnormativeAspectsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NormativeAspects",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NormativeAspects");
        }
    }
}
