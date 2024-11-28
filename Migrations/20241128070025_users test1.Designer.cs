﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using programming_work_backend.Data;

#nullable disable

namespace programming_work_backend.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20241128070025_users test1")]
    partial class userstest1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("programming_work_backend.Domain.AcademicActivities.Models.AcademicActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("HAcom")
                        .HasColumnType("int");

                    b.Property<int>("HIndep")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<short>("Mirror")
                        .HasColumnType("smallint");

                    b.Property<string>("MirrorCountry")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MirrorEntity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingArea")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AcademicActivities");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Accreditations.Models.Acreditation", b =>
                {
                    b.Property<int>("Resolution")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Resolution"));

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Resolution");

                    b.HasIndex("ProgrammId");

                    b.ToTable("Accreditations");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Alliances.Models.Alliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlliedId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlliedId");

                    b.HasIndex("ProgrammId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Alliances");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Allieds.Models.Allied", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Company_reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contact_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Allieds");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Approaches.Models.Approach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Approaches");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Awards.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GrantingEntity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProgrammId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("programming_work_backend.Domain.CarInnovations.Models.CarInnovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CarInnovations");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Faculties.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Internships.Models.Internship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammId");

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("programming_work_backend.Domain.NormativeAspectProgramms.Models.NormativeAspectProgramm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("NormativeAspectId")
                        .HasColumnType("int");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormativeAspectId");

                    b.HasIndex("ProgrammId");

                    b.ToTable("NormativeAspectProgramms");
                });

            modelBuilder.Entity("programming_work_backend.Domain.NormativeAspects.Models.NormativeAspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NormativeAspects");
                });

            modelBuilder.Entity("programming_work_backend.Domain.PracticeStrategys.Models.PracticeStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type_practice")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PracticeStrategys");
                });

            modelBuilder.Entity("programming_work_backend.Domain.ProgrammCarInnovations.Models.ProgrammCarInnovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarInnovationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProgrammId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarInnovationId");

                    b.HasIndex("ProgrammId");

                    b.ToTable("ProgrammCarInnovations");
                });

            modelBuilder.Entity("programming_work_backend.Domain.ProgrammPracticeStrategys.Models.ProgrammPracticeStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PracticeStrategyId")
                        .HasColumnType("int");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PracticeStrategyId");

                    b.HasIndex("ProgrammId");

                    b.ToTable("ProgrammPracticeStrategys");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Programms.Models.Programm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ClosingDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("GraduatesCount")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastUpdateDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumberCohorts")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistries.Models.QualifiedRegistry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcomHours")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreditAmount")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DegreeType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DurationSemesters")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DurationYears")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IndependentHours")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Methodology")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammId");

                    b.ToTable("QualifiedRegistries");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistryAcademicActivities.Models.QualifiedRegistryAcademicActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AcademicActivityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("QualifiedRegistryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademicActivityId");

                    b.HasIndex("QualifiedRegistryId");

                    b.ToTable("QualifiedRegistryAcademicActivities");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistryApproaches.Models.QualifiedRegistryApproach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApproachId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("QualifiedRegistryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("QualifiedRegistryId");

                    b.ToTable("QualifiedRegistryApproaches");
                });

            modelBuilder.Entity("programming_work_backend.Domain.TeacherPrograms.Models.TeacherProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dedication")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Modality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherPrograms");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Teachers.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CvUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Escalafon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MainResearchLine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MinScienceCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MinScienceConvention")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Universities.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Users.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mateo",
                            Password = "123",
                            Rol = "empleado"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Marcos",
                            Password = "123",
                            Rol = "empleado"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lucas",
                            Password = "123",
                            Rol = "asesor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Juan",
                            Password = "123",
                            Rol = "administrador"
                        });
                });

            modelBuilder.Entity("programming_work_backend.Domain.Accreditations.Models.Acreditation", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Alliances.Models.Alliance", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Allieds.Models.Allied", "Allied")
                        .WithMany()
                        .HasForeignKey("AlliedId");

                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("programming_work_backend.Domain.Teachers.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Allied");

                    b.Navigation("Programm");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Awards.Models.Award", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Faculties.Models.Faculty", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Universities.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId");

                    b.Navigation("University");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Internships.Models.Internship", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.NormativeAspectProgramms.Models.NormativeAspectProgramm", b =>
                {
                    b.HasOne("programming_work_backend.Domain.NormativeAspects.Models.NormativeAspect", "NormativeAspect")
                        .WithMany()
                        .HasForeignKey("NormativeAspectId");

                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.Navigation("NormativeAspect");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.ProgrammCarInnovations.Models.ProgrammCarInnovation", b =>
                {
                    b.HasOne("programming_work_backend.Domain.CarInnovations.Models.CarInnovation", "CarInnovation")
                        .WithMany()
                        .HasForeignKey("CarInnovationId");

                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarInnovation");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.ProgrammPracticeStrategys.Models.ProgrammPracticeStrategy", b =>
                {
                    b.HasOne("programming_work_backend.Domain.PracticeStrategys.Models.PracticeStrategy", "PracticeStrategy")
                        .WithMany()
                        .HasForeignKey("PracticeStrategyId");

                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.Navigation("PracticeStrategy");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.Programms.Models.Programm", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Faculties.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistries.Models.QualifiedRegistry", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistryAcademicActivities.Models.QualifiedRegistryAcademicActivity", b =>
                {
                    b.HasOne("programming_work_backend.Domain.AcademicActivities.Models.AcademicActivity", "AcademicActivity")
                        .WithMany()
                        .HasForeignKey("AcademicActivityId");

                    b.HasOne("programming_work_backend.Domain.QualifiedRegistries.Models.QualifiedRegistry", "QualifiedRegistry")
                        .WithMany()
                        .HasForeignKey("QualifiedRegistryId");

                    b.Navigation("AcademicActivity");

                    b.Navigation("QualifiedRegistry");
                });

            modelBuilder.Entity("programming_work_backend.Domain.QualifiedRegistryApproaches.Models.QualifiedRegistryApproach", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Approaches.Models.Approach", "Approach")
                        .WithMany()
                        .HasForeignKey("ApproachId");

                    b.HasOne("programming_work_backend.Domain.QualifiedRegistries.Models.QualifiedRegistry", "QualifiedRegistry")
                        .WithMany()
                        .HasForeignKey("QualifiedRegistryId");

                    b.Navigation("Approach");

                    b.Navigation("QualifiedRegistry");
                });

            modelBuilder.Entity("programming_work_backend.Domain.TeacherPrograms.Models.TeacherProgram", b =>
                {
                    b.HasOne("programming_work_backend.Domain.Programms.Models.Programm", "Programm")
                        .WithMany()
                        .HasForeignKey("ProgrammId");

                    b.HasOne("programming_work_backend.Domain.Teachers.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Programm");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
