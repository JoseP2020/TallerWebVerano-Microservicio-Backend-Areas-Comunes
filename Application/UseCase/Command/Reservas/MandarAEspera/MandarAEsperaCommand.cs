using MediatR;

namespace Application.UseCase.Command.Reservas.MandarAEspera
{
    public record MandarAEsperaCommand : IRequest<Guid>
    {
        public Guid ReservaId { get; set; }

    }
}
