using System;
using Microsoft.EntityFrameworkCore;

namespace programming_work_backend.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {

    }
}