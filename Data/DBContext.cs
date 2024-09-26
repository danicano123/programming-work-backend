using System;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Domain.Focus.Models;
using programming_work_backend.Domain.NormativeAspects.Models;
using programming_work_backend.Domain.University.Models;

namespace programming_work_backend.Data;

public class DBContext : DbContext
{
    // Conection constructor
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {

    }
    // Models constructor
    public DbSet<NormativeAspect> NormativeAspects { get; set; }
    public DbSet<University> University { get; set; }
    public DbSet<Focus> Focus { get; set; }
}