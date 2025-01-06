using MediatR;

namespace Application.Cursos.CursoCreate
{
    public class CursoCreateCommand
    {
        public record CursoCreateCommandRequest(CursoCreateRequest cursoCreateRequest) : IRequest<Guid>;
    }
}