using MediatR;

namespace Application.UseCase.Command.AreasComunes.EditarAreaComun
{
    public record EditarAreaComunCommand : IRequest<Guid>
    {
        public Guid AreaComunId { get; set; }
        public Guid CondominioId { get; set; }
        public Guid TurnoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CapacidadMaxima { get; set; }
        public string Estado { get; set; }
        public DateTime? FinCierre { get; set; }

    }
}
