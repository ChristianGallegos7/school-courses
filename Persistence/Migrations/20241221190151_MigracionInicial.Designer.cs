﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241221190151_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4");

            modelBuilder.Entity("Domain.Calificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alumno")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Puntaje")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("calificaciones", (string)null);
                });

            modelBuilder.Entity("Domain.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("cursos", (string)null);
                });

            modelBuilder.Entity("Domain.CursoInstructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("curso_instructores", (string)null);
                });

            modelBuilder.Entity("Domain.CursoPrecio", b =>
                {
                    b.Property<Guid>("PrecioId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.HasKey("PrecioId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("curso_precios", (string)null);
                });

            modelBuilder.Entity("Domain.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Grado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("instructores", (string)null);
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("imagenes", (string)null);
                });

            modelBuilder.Entity("Domain.Precio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PrecioActual")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PrecioPromocion")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("precios", (string)null);
                });

            modelBuilder.Entity("Domain.Calificacion", b =>
                {
                    b.HasOne("Domain.Curso", "Curso")
                        .WithMany("Calificaciones")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Domain.CursoInstructor", b =>
                {
                    b.HasOne("Domain.Curso", "Curso")
                        .WithMany("CursoInstructores")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Instructor", "Instructor")
                        .WithMany("CursosInstructores")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Domain.CursoPrecio", b =>
                {
                    b.HasOne("Domain.Curso", "Curso")
                        .WithMany("CursoPrecios")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Precio", "Precio")
                        .WithMany("CursoPrecios")
                        .HasForeignKey("PrecioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Precio");
                });

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.HasOne("Domain.Curso", "Curso")
                        .WithMany("Photos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Domain.Curso", b =>
                {
                    b.Navigation("Calificaciones");

                    b.Navigation("CursoInstructores");

                    b.Navigation("CursoPrecios");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Domain.Instructor", b =>
                {
                    b.Navigation("CursosInstructores");
                });

            modelBuilder.Entity("Domain.Precio", b =>
                {
                    b.Navigation("CursoPrecios");
                });
#pragma warning restore 612, 618
        }
    }
}
