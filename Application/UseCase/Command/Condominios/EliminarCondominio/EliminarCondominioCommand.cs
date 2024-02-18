using MediatR;

namespace Application.UseCase.Command.Condominios.EliminarCondominio
{
    public record EliminarCondominioCommand : IRequest<Guid>
    {
        public Guid CondominioId { get; set; }
    }
}
