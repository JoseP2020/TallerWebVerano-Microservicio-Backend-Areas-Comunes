using MediatR;

namespace Application.UseCase.Command.Turnos.EliminarTurno
{
    public record EliminarTurnoCommand : IRequest<Guid>
    {
        public Guid TurnoId { get; set; }
    }
}
