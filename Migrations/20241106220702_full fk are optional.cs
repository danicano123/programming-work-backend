using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_work_backend.Migrations
{
    /// <inheritdoc />
    public partial class fullfkareoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alliances_Allieds_AlliedId",
                table: "Alliances");

            migrationBuilder.DropForeignKey(
                name: "FK_Alliances_Teachers_TeacherId",
                table: "Alliances");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Programs_ProgrammId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativeAspectProgramms_NormativeAspects_NormativeAspectId",
                table: "NormativeAspectProgramms");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativeAspectProgramms_Programs_ProgrammId",
                table: "NormativeAspectProgramms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammCarInnovations_CarInnovations_CarInnovationId",
                table: "ProgrammCarInnovations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammPracticeStrategys_PracticeStrategys_PracticeStrategy~",
                table: "ProgrammPracticeStrategys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammPracticeStrategys_Programs_ProgrammId",
                table: "ProgrammPracticeStrategys");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Faculties_FacultyId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistries_Programs_ProgrammId",
                table: "QualifiedRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistryApproaches_Approaches_ApproachId",
                table: "QualifiedRegistryApproaches");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistryApproaches_QualifiedRegistries_QualifiedReg~",
                table: "QualifiedRegistryApproaches");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPrograms_Programs_ProgrammId",
                table: "TeacherPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPrograms_Teachers_TeacherId",
                table: "TeacherPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Programs_FacultyId",
                table: "Programs");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherPrograms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "TeacherPrograms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QualifiedRegistryId",
                table: "QualifiedRegistryApproaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApproachId",
                table: "QualifiedRegistryApproaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "QualifiedRegistries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Programs",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "ProgrammPracticeStrategys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PracticeStrategyId",
                table: "ProgrammPracticeStrategys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarInnovationId",
                table: "ProgrammCarInnovations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "NormativeAspectProgramms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NormativeAspectId",
                table: "NormativeAspectProgramms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "Internships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Faculties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Alliances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AlliedId",
                table: "Alliances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AcademicActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrainingArea = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HAcom = table.Column<int>(type: "int", nullable: false),
                    HIndep = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mirror = table.Column<short>(type: "smallint", nullable: false),
                    MirrorEntity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MirrorCountry = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgrammId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicActivities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accreditations",
                columns: table => new
                {
                    Resolution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Qualification = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EndDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgrammId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accreditations", x => x.Resolution);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GrantingEntity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgrammId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Programs_ProgrammId",
                        column: x => x.ProgrammId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QualifiedRegistryAcademicActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QualifiedRegistryId = table.Column<int>(type: "int", nullable: true),
                    AcademicActivityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifiedRegistryAcademicActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualifiedRegistryAcademicActivities_AcademicActivities_Acade~",
                        column: x => x.AcademicActivityId,
                        principalTable: "AcademicActivities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualifiedRegistryAcademicActivities_QualifiedRegistries_Qual~",
                        column: x => x.QualifiedRegistryId,
                        principalTable: "QualifiedRegistries",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_ProgrammId",
                table: "Awards",
                column: "ProgrammId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifiedRegistryAcademicActivities_AcademicActivityId",
                table: "QualifiedRegistryAcademicActivities",
                column: "AcademicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_QualifiedRegistryAcademicActivities_QualifiedRegistryId",
                table: "QualifiedRegistryAcademicActivities",
                column: "QualifiedRegistryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alliances_Allieds_AlliedId",
                table: "Alliances",
                column: "AlliedId",
                principalTable: "Allieds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alliances_Teachers_TeacherId",
                table: "Alliances",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Programs_ProgrammId",
                table: "Internships",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NormativeAspectProgramms_NormativeAspects_NormativeAspectId",
                table: "NormativeAspectProgramms",
                column: "NormativeAspectId",
                principalTable: "NormativeAspects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NormativeAspectProgramms_Programs_ProgrammId",
                table: "NormativeAspectProgramms",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammCarInnovations_CarInnovations_CarInnovationId",
                table: "ProgrammCarInnovations",
                column: "CarInnovationId",
                principalTable: "CarInnovations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammPracticeStrategys_PracticeStrategys_PracticeStrategy~",
                table: "ProgrammPracticeStrategys",
                column: "PracticeStrategyId",
                principalTable: "PracticeStrategys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammPracticeStrategys_Programs_ProgrammId",
                table: "ProgrammPracticeStrategys",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistries_Programs_ProgrammId",
                table: "QualifiedRegistries",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistryApproaches_Approaches_ApproachId",
                table: "QualifiedRegistryApproaches",
                column: "ApproachId",
                principalTable: "Approaches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistryApproaches_QualifiedRegistries_QualifiedReg~",
                table: "QualifiedRegistryApproaches",
                column: "QualifiedRegistryId",
                principalTable: "QualifiedRegistries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPrograms_Programs_ProgrammId",
                table: "TeacherPrograms",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPrograms_Teachers_TeacherId",
                table: "TeacherPrograms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alliances_Allieds_AlliedId",
                table: "Alliances");

            migrationBuilder.DropForeignKey(
                name: "FK_Alliances_Teachers_TeacherId",
                table: "Alliances");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Programs_ProgrammId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativeAspectProgramms_NormativeAspects_NormativeAspectId",
                table: "NormativeAspectProgramms");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativeAspectProgramms_Programs_ProgrammId",
                table: "NormativeAspectProgramms");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammCarInnovations_CarInnovations_CarInnovationId",
                table: "ProgrammCarInnovations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammPracticeStrategys_PracticeStrategys_PracticeStrategy~",
                table: "ProgrammPracticeStrategys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammPracticeStrategys_Programs_ProgrammId",
                table: "ProgrammPracticeStrategys");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistries_Programs_ProgrammId",
                table: "QualifiedRegistries");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistryApproaches_Approaches_ApproachId",
                table: "QualifiedRegistryApproaches");

            migrationBuilder.DropForeignKey(
                name: "FK_QualifiedRegistryApproaches_QualifiedRegistries_QualifiedReg~",
                table: "QualifiedRegistryApproaches");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPrograms_Programs_ProgrammId",
                table: "TeacherPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPrograms_Teachers_TeacherId",
                table: "TeacherPrograms");

            migrationBuilder.DropTable(
                name: "Accreditations");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "QualifiedRegistryAcademicActivities");

            migrationBuilder.DropTable(
                name: "AcademicActivities");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "TeacherPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QualifiedRegistryId",
                table: "QualifiedRegistryApproaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApproachId",
                table: "QualifiedRegistryApproaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "QualifiedRegistries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Programs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "ProgrammPracticeStrategys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PracticeStrategyId",
                table: "ProgrammPracticeStrategys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarInnovationId",
                table: "ProgrammCarInnovations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "NormativeAspectProgramms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NormativeAspectId",
                table: "NormativeAspectProgramms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammId",
                table: "Internships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Alliances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlliedId",
                table: "Alliances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_FacultyId",
                table: "Programs",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alliances_Allieds_AlliedId",
                table: "Alliances",
                column: "AlliedId",
                principalTable: "Allieds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alliances_Teachers_TeacherId",
                table: "Alliances",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Programs_ProgrammId",
                table: "Internships",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormativeAspectProgramms_NormativeAspects_NormativeAspectId",
                table: "NormativeAspectProgramms",
                column: "NormativeAspectId",
                principalTable: "NormativeAspects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormativeAspectProgramms_Programs_ProgrammId",
                table: "NormativeAspectProgramms",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammCarInnovations_CarInnovations_CarInnovationId",
                table: "ProgrammCarInnovations",
                column: "CarInnovationId",
                principalTable: "CarInnovations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammPracticeStrategys_PracticeStrategys_PracticeStrategy~",
                table: "ProgrammPracticeStrategys",
                column: "PracticeStrategyId",
                principalTable: "PracticeStrategys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammPracticeStrategys_Programs_ProgrammId",
                table: "ProgrammPracticeStrategys",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Faculties_FacultyId",
                table: "Programs",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistries_Programs_ProgrammId",
                table: "QualifiedRegistries",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistryApproaches_Approaches_ApproachId",
                table: "QualifiedRegistryApproaches",
                column: "ApproachId",
                principalTable: "Approaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualifiedRegistryApproaches_QualifiedRegistries_QualifiedReg~",
                table: "QualifiedRegistryApproaches",
                column: "QualifiedRegistryId",
                principalTable: "QualifiedRegistries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPrograms_Programs_ProgrammId",
                table: "TeacherPrograms",
                column: "ProgrammId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPrograms_Teachers_TeacherId",
                table: "TeacherPrograms",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
