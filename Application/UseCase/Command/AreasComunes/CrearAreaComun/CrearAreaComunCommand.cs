using MediatR;

namespace Application.UseCase.Command.AreasComunes.CrearAreaComun
{
    public record CrearAreaComunCommand : IRequest<Guid>
    {
        public Guid CondominioId { get; set; }
        public Guid TurnoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CapacidadMaxima { get; set; }
        public string Estado { get; set; }

    }
}
