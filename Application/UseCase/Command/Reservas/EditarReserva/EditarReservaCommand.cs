using MediatR;

namespace Application.UseCase.Command.Reservas.EditarReserva
{
    public record EditarReservaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }
        public Guid AreaComunId { get; set; }
        public Guid ResidenteId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

    }
}
