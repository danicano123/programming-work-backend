using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_work_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreationS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualifiedRegistryApproaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QualifiedRegistryId = table.Column<int>(type: "int", nullable: false),
                    ApproachId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifiedRegistryApproaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualifiedRegistryApproaches_Approaches_ApproachId",
                        column: x => x.ApproachId,
                        principalTable: "Approaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualifiedRegistryApproaches_QualifiedRegistries_QualifiedReg~",
                        column: x => x.QualifiedRegistryId,
                        principalTable: "QualifiedRegistries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QualifiedRegistryApproaches_ApproachId",
                table: "QualifiedRegistryApproaches",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifiedRegistryApproaches_QualifiedRegistryId",
                table: "QualifiedRegistryApproaches",
                column: "QualifiedRegistryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualifiedRegistryApproaches");
        }
    }
}
