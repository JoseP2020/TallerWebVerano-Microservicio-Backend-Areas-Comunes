using Application.Dto.Residentes;
using MediatR;

namespace Application.UseCase.Query.Residentes
{
    public class GetListaResidentesQuery : IRequest<IEnumerable<ResidenteDto>>
    {
    }
}
