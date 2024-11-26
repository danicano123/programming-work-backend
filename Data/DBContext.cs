using Microsoft.EntityFrameworkCore;
using programming_work_backend.Domain.NormativeAspects.Models;
using programming_work_backend.Domain.Approaches.Models;
using programming_work_backend.Domain.Universities.Models;
using programming_work_backend.Domain.Allieds.Models;
using programming_work_backend.Domain.PracticeStrategys.Models;
using programming_work_backend.Domain.CarInnovations.Models;
using programming_work_backend.Domain.Teachers.Models;
using programming_work_backend.Domain.Programms.Models;
using programming_work_backend.Domain.Faculties.Models;
using programming_work_backend.Domain.Alliances.Models;
using programming_work_backend.Domain.ProgrammCarInnovations.Models;
using programming_work_backend.Domain.ProgrammPracticeStrategys.Models;
using programming_work_backend.Domain.NormativeAspectProgramms.Models;
using programming_work_backend.Domain.Internships.Models;
using programming_work_backend.Domain.QualifiedRegistries.Models;
using programming_work_backend.Domain.QualifiedRegistryApproaches.Models;
using programming_work_backend.Domain.Users.Models;
using programming_work_backend.Domain.Accreditations.Models;
using programming_work_backend.Domain.Awards.Models;
using programming_work_backend.Domain.AcademicActivities.Models;
using programming_work_backend.Domain.QualifiedRegistryAcademicActivities.Models;
using programming_work_backend.Domain.TeacherPrograms.Models;

namespace programming_work_backend.Data
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<Approach> Approaches { get; set; }
        public DbSet<NormativeAspect> NormativeAspects { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Allied> Allieds { get; set; }
        public DbSet<PracticeStrategy> PracticeStrategys { get; set; }
        public DbSet<CarInnovation> CarInnovations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherProgram> TeacherPrograms { get; set; }
        public DbSet<Programm> Programs { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<ProgrammCarInnovation> ProgrammCarInnovations { get; set; }
        public DbSet<ProgrammPracticeStrategy> ProgrammPracticeStrategys { get; set; }
        public DbSet<NormativeAspectProgramm> NormativeAspectProgramms { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<QualifiedRegistry> QualifiedRegistries { get; set; }
        public DbSet<QualifiedRegistryApproach> QualifiedRegistryApproaches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Acreditation> Accreditations { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AcademicActivity> AcademicActivities { get; set; }
        public DbSet<QualifiedRegistryAcademicActivity> QualifiedRegistryAcademicActivities { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre 256+ y Teacher
            modelBuilder.Entity<TeacherProgram>()
                .HasOne(tp => tp.Teacher)
                .WithMany()
                .HasForeignKey(tp => tp.TeacherId);

            // Configuración de la relación entre TeacherProgram y Programm
            modelBuilder.Entity<TeacherProgram>()
                .HasOne(tp => tp.Programm)
                .WithMany()
                .HasForeignKey(tp => tp.ProgrammId);

            // Configuración de la relación entre Alliance y Programm
            modelBuilder.Entity<Alliance>()
                .HasOne(a => a.Programm)
                .WithMany()
                .HasForeignKey(a => a.ProgrammId);

            // Configuración de la relación entre Alliance y Allied
            modelBuilder.Entity<Alliance>()
                .HasOne(a => a.Allied)
                .WithMany()
                .HasForeignKey(a => a.AlliedId);

            // Configuración de la relación entre Alliance y Teacher
            modelBuilder.Entity<Alliance>()
                .HasOne(a => a.Teacher)
                .WithMany()
                .HasForeignKey(a => a.TeacherId);

            // Configuración de la relación entre ProgrammCarInnovation y Programm
            modelBuilder.Entity<ProgrammCarInnovation>()
                .HasOne(pci => pci.Programm)
                .WithMany()
                .HasForeignKey(pci => pci.ProgrammId);

            // Configuración de la relación entre ProgrammCarInnovation y CarInnovation
            modelBuilder.Entity<ProgrammCarInnovation>()
                .HasOne(pci => pci.CarInnovation)
                .WithMany()
                .HasForeignKey(pci => pci.CarInnovationId);

            // Configuración de la relación entre ProgrammPracticeStrategy y Programm
            modelBuilder.Entity<ProgrammPracticeStrategy>()
                .HasOne(pps => pps.Programm)
                .WithMany()
                .HasForeignKey(pps => pps.ProgrammId);

            // Configuración de la relación entre ProgrammPracticeStrategy y PracticeStrategy
            modelBuilder.Entity<ProgrammPracticeStrategy>()
                .HasOne(pps => pps.PracticeStrategy)
                .WithMany()
                .HasForeignKey(pps => pps.PracticeStrategyId);

            // Configuración de la relación entre Faculty y University
            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.University)
                .WithMany()
                .HasForeignKey(f => f.UniversityId);


            modelBuilder.Entity<NormativeAspectProgramm>()
                .HasOne(nap => nap.NormativeAspect)
                .WithMany()
                .HasForeignKey(nap => nap.NormativeAspectId);

            modelBuilder.Entity<NormativeAspectProgramm>()
                .HasOne(nap => nap.Programm)
                .WithMany()
                .HasForeignKey(nap => nap.ProgrammId);

            modelBuilder.Entity<Internship>()
                .HasOne(i => i.Programm)
                .WithMany()
                .HasForeignKey(i => i.ProgrammId);

            modelBuilder.Entity<QualifiedRegistry>()
                .HasOne(qr => qr.Programm)
                .WithMany()
                .HasForeignKey(qr => qr.ProgrammId);

            modelBuilder.Entity<QualifiedRegistryApproach>()
                .HasOne(qra => qra.QualifiedRegistry)
                .WithMany()
                .HasForeignKey(qra => qra.QualifiedRegistryId);

            modelBuilder.Entity<QualifiedRegistryApproach>()
                .HasOne(qra => qra.Approach)
                .WithMany()
                .HasForeignKey(qra => qra.ApproachId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
