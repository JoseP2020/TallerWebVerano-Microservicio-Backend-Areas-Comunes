using MediatR;

namespace Application.UseCase.Command.Residentes.CrearResidente
{

    public record CrearResidenteCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
    }
}
