// using Domain;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// using var context = new ApplicationDbContext();


// var cursoNuevo = new Curso
// {
//     Id = new Guid(),
//     Titulo = "Curso de Laravel",
//     Descripcion = "El mejor curso de laravel"
// };

// context.Add(cursoNuevo);

// await context.SaveChangesAsync();

// var cursos = await context.Cursos!.ToListAsync();

// foreach (var curso in cursos)
// {
//     Console.WriteLine($"Id: {curso.Id} Titulo: {curso.Titulo}");
// }