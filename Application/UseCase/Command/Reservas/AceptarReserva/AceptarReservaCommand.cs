using MediatR;

namespace Application.UseCase.Command.Reservas.AceptarReserva
{
    public record AceptarReservaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }

    }
}
