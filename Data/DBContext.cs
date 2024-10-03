using Microsoft.EntityFrameworkCore;
using programming_work_backend.Domain.NormativeAspects.Models;
using programming_work_backend.Domain.Approaches.Models;
using programming_work_backend.Domain.Universities.Models;
using programming_work_backend.Domain.Allieds.Models;
using programming_work_backend.Domain.PracticeStrategys.Models;

namespace programming_work_backend.Data;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{
    // Conection constructor
        public DbSet<Approach> Approaches { get; set; }

        public DbSet<NormativeAspect> NormativeAspects { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<Allied> Allieds { get; set; }

        public DbSet<PracticeStrategy> PracticeStrategys { get; set; }

    
    
}