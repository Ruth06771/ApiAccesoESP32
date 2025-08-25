using ApiAccesoESP32.DTOs;
using ApiAccesoESP32.models;
using Microsoft.EntityFrameworkCore;

namespace ApiAccesoESP32.Data
{
    public class AccesoContext : DbContext
    {
        public AccesoContext(DbContextOptions<AccesoContext> options)
              : base(options)
        {
        }

        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public DbSet<ColumnaDTO> Columnas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esto hace que EF Core busque la tabla "registros" en minúscula en PostgreSQL
            modelBuilder.Entity<Registro>().ToTable("registros");

            // Marca que ColumnaDTO no tiene clave primaria, porque solo es para consulta SQL
            modelBuilder.Entity<ColumnaDTO>().HasNoKey();

            // Puedes mapear otras tablas si quieres
            // modelBuilder.Entity<Persona>().ToTable("personas");
        }
    }
}
