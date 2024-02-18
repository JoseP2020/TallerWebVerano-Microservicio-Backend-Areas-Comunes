using MediatR;

namespace Application.UseCase.Command.Condominios.CrearCondominio
{
    public record CrearCondominioCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
    }
}
