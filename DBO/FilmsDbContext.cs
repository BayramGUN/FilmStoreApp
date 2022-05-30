using Microsoft.EntityFrameworkCore;
using FilmsApi.Entities;

namespace FilmsApi.DBO;

public class FilmsDbContext : DbContext, IFilmsDbContext
{
    public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options) 
    { }
    public DbSet<Film> Films { get; set; }
    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}

