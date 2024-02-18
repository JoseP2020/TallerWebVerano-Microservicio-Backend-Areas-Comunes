using MediatR;

namespace Application.UseCase.Command.Condominios.EditarCondominio
{
    public record EditarCondominioCommand : IRequest<Guid>
    {
        public Guid CondominioId { get; set; }
        public string Nombre { get; set; }
    }
}
