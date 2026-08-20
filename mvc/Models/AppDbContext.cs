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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla Propietario
            modelBuilder.Entity<Propietario>()
                .ToTable("propietario");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Nombre)
                .HasColumnName("nombre");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Apellido)
                .HasColumnName("apellido");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Dni)
                .HasColumnName("dni");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Telefono)
                .HasColumnName("telefono");

            modelBuilder.Entity<Propietario>()
                .Property(p => p.Email)
                .HasColumnName("email");


            // Tabla Inmueble
            modelBuilder.Entity<Inmueble>()
                .ToTable("inmueble");

            // Relacion Inmueble -> Propietario
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Propietario)
                .WithMany()
                .HasForeignKey(i => i.PropietarioId);
        }
    }
}