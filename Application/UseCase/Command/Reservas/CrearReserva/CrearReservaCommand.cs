using MediatR;

namespace Application.UseCase.Command.Reservas.CrearReserva
{
    public record CrearReservaCommand : IRequest<Guid>
    {
        public Guid AreaComunId { get; set; }
        public Guid ResidenteId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

    }
}
