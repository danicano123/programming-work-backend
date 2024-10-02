using Microsoft.EntityFrameworkCore;
using programming_work_backend.Domain.NormativeAspects.Models;
using programming_work_backend.Domain.Approaches.Models;
using programming_work_backend.Domain.Universities.Models;

namespace programming_work_backend.Data;

public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
{
    // Conection constructor
        public DbSet<Approach> Approaches { get; set; }
        public DbSet<NormativeAspect> NormativeAspects { get; set; }

        public DbSet<University> Universities { get; set; }
    
    
}