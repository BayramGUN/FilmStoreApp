using Microsoft.EntityFrameworkCore;


namespace FilmsApi.DBO;

public class FilmsDbContext : DbContext
{
    public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options) 
    { }
    public DbSet<Film> Films { get; set; }
}

