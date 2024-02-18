using Application.Dto.Turnos;
using MediatR;

namespace Application.UseCase.Query.Turnos
{
    public class GetListaTurnosQuery : IRequest<IEnumerable<TurnoDto>>
    {
    }
}
