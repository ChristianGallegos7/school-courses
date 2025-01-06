using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Calificacion>? Calificaciones { get; set; }
        public DbSet<Precio>? Precios { get; set; }
        public DbSet<Instructor>? Instructores { get; set; }

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

            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Photos)
                .WithOne(m => m.Curso)
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

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
<<<<<<< HEAD


            CargarDataSeguridad(modelBuilder);
        }

        private void CargarDataSeguridad(ModelBuilder modelBuilder){
            var adminId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRol>
=======
            CargarDataSeguridad(modelBuilder);
        }

        private void CargarDataSeguridad(ModelBuilder modelBuilder)
        {
            var adminId = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminId,
                    Name = CustomRoles.ADMIN,
                    NormalizedName = CustomRoles.ADMIN
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = clientId,
                   Name = CustomRoles.CLIENT,
                   NormalizedName = CustomRoles.CLIENT
               }
            );

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(
                   new IdentityRoleClaim<string>
                   {
                       Id = 1,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.CURSO_READ,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 2,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.CURSO_UPDATE,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 3,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.CURSO_WRITE,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 4,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.CURSO_DELETE,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 5,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.INSTRUCTOR_CREATE,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 6, // Cambiado a un valor único
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.INSTRUCTOR_READ,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 7,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.INSTRUCTOR_DELETE,
                       RoleId = adminId
                   },
                   new IdentityRoleClaim<string>
                   {
                       Id = 8,
                       ClaimType = CustomClaims.POLICIES,
                       ClaimValue = PolicyMaster.INSTRUCTOR_UPDATE,
                       RoleId = adminId
                   },
                    new IdentityRoleClaim<string>
                    {
                        Id = 9,
                        ClaimType = CustomClaims.POLICIES,
                        ClaimValue = PolicyMaster.COMENTARIO_READ,
                        RoleId = adminId
                    },
                    new IdentityRoleClaim<string>
                    {
                        Id = 10,
                        ClaimType = CustomClaims.POLICIES,
                        ClaimValue = PolicyMaster.COMENTARIO_CREATE,
                        RoleId = adminId
                    },
                    new IdentityRoleClaim<string>
                    {
                        Id = 11,
                        ClaimType = CustomClaims.POLICIES,
                        ClaimValue = PolicyMaster.COMENTARIO_DELETE,
                        RoleId = adminId
                    },
                    new IdentityRoleClaim<string>
                    {
                        Id = 12,
                        ClaimType = CustomClaims.POLICIES,
                        ClaimValue = PolicyMaster.CURSO_READ,
                        RoleId = clientId
                    }
            );
>>>>>>> 46bf8f2327f41ecdb341c61d074271bb43f4f8a6
        }
    }

}