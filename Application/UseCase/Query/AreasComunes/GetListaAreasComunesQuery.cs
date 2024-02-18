using Application.Dto.AreasComunes;
using MediatR;

namespace Application.UseCase.Query.AreasComunes
{
    public class GetListaAreasComunesQuery : IRequest<IEnumerable<AreaComunDto>>
    {
    }
}
