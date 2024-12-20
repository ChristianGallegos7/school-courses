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

            //Relacion muchos a muchos entre Curso y Precios
            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Precios)
                .WithMany(m => m.Cursos)
                .UsingEntity<CursoPrecio>(
                    j => j
                        .HasOne(p => p.Precio)
                        .WithMany(p => p.CursoPrecios)
                        .HasForeignKey(p => p.PrecioId),
                    j => j
                        .HasOne(p => p.Curso)
                        .WithMany(p => p.CursoPrecios)
                        .HasForeignKey(p => p.CursoId),
                    j =>
                    {
                        j.HasKey(t => new { t.PrecioId, t.CursoId });
                    }
            );

            //Relacion muchos a muchos entre Curso e Instructores
            modelBuilder.Entity<Curso>()
                .HasMany(i => i.Instructores)
                .WithMany(c => c.Cursos)
                .UsingEntity<CursoInstructor>(
                    j => j
                        .HasOne(i => i.Instructor)
                        .WithMany(i => i.CursosInstructores)
                        .HasForeignKey(i => i.InstructorId),
                    j => j
                        .HasOne(i => i.Curso)
                        .WithMany(i => i.CursoInstructores)
                        .HasForeignKey(i => i.CursoId),
                    j =>
                    {
                        j.HasKey(t => new { t.InstructorId, t.CursoId });
                    }
                );
        }
    }
}
