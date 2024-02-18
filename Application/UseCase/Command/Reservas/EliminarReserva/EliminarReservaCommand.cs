using MediatR;

namespace Application.UseCase.Command.Reservas.EliminarReserva
{
    public record EliminarReservaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }

    }
}
