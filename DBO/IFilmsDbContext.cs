using Microsoft.EntityFrameworkCore;
using FilmsApi.Entities;

namespace FilmsApi.DBO;

public interface IFilmsDbContext
{    
     DbSet<Film> Films { get; set; }
     DbSet<User> Users { get; set; }

     int SaveChanges();
}
