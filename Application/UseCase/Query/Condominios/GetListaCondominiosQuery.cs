using Application.Dto.Condominios;
using MediatR;

namespace Application.UseCase.Query.Condominios
{
    public class GetListaCondominiosQuery : IRequest<IEnumerable<CondominioDto>>
    {
    }
}
