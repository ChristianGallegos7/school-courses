using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LocalDatabase.db")
                .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                Microsoft.Extensions.Logging.LogLevel.Information
                ).EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>().ToTable("cursos");

            modelBuilder.Entity<Instructor>().ToTable("instructores");

            modelBuilder.Entity<CursoInstructor>().ToTable("curso_instructores");

            modelBuilder.Entity<Precio>().ToTable("precios");

            modelBuilder.Entity<CursoPrecio>().ToTable("curso_precios");

            modelBuilder.Entity<Calificacion>().ToTable("calificaciones");

            modelBuilder.Entity<Photo>().ToTable("imagenes");

            modelBuilder.Entity<Precio>()
                .Property(p => p.PrecioActual)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Precio>()
                .Property(p => p.PrecioPromocion)
                .HasPrecision(10, 2);

            //Relacion uno a muchos entre la tabla Curso y Photos, un curso tiene muchas fotos
            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Photos)
                .WithOne(m => m.Curso)
                .HasForeignKey(m => m.CursoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            //Relacion uno a muchos entre la tabla Curso y Calificacies, un curso tiene varias calificaciones
            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Calificaciones)
                .WithOne(m => m.Curso)
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Precios)
                .WithMany(m => m.Cursos)
                .UsingEntity<CursoPrecio>(
                    j => j
                        .HasOne(p => p.Precio )
                        .WithMany(p  => p.CursoPrecios)
                );


        }
    }
}
