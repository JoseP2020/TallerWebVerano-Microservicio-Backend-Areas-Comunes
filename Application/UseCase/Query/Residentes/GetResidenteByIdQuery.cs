using Application.Dto.Residentes;
using MediatR;

namespace Application.UseCase.Query.Residentes
{
    public class GetResidenteByIdQuery : IRequest<List<ResidenteDto>>
    {
        public string Nombre { get; set; }

    }
}