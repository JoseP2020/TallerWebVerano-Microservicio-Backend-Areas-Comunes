using Application.Dto.Reservas;
using MediatR;

namespace Application.UseCase.Query.Reservas
{
    public class GetListaReservasQuery : IRequest<IEnumerable<ReservaDto>>
    {
    }
}
