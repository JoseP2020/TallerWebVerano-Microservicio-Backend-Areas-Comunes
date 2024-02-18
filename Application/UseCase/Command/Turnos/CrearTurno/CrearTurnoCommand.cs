using MediatR;

namespace Application.UseCase.Command.Turnos.CrearTurno
{
    public record CrearTurnoCommand : IRequest<Guid>
    {
        public string Inicio { get; set; }

        public string Fin { get; set; }

    }
}
