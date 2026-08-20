using Microsoft.EntityFrameworkCore;

namespace mvc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Inmueble> Inmuebles { get; set; }
    }
}