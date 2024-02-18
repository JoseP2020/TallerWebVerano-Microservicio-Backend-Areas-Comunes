using MediatR;

namespace Application.UseCase.Command.Residentes.EditarResidente
{
    public record EditarResidenteCommand : IRequest<Guid>
    {
        public Guid ResidenteId { get; set; }
        public string Nombre { get; set; }
    }
}
