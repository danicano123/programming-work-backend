using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_work_backend.Migrations
{
    /// <inheritdoc />
    public partial class accreditationhasfkwithprogramm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accreditations_ProgrammId",
                table: "Accreditations",
                column: "ProgrammId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accreditations_Programs_ProgrammId",
                table: "Accreditations",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accreditations_Programs_ProgrammId",
                table: "Accreditations");

            migrationBuilder.DropIndex(
                name: "IX_Accreditations_ProgrammId",
                table: "Accreditations");
        }
    }
}
