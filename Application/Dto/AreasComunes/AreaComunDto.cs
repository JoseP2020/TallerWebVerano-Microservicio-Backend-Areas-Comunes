using Application.Dto.Condominios;
using Application.Dto.Turnos;

namespace Application.Dto.AreasComunes
{
    public class AreaComunDto
    {
        public Guid Id { get; set; }
        public TurnoDto Turno { get; set; }
        public CondominioDto Condominio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CapacidadMaxima { get; set; }
        public string Estado { get; set; }
        public DateTime FinCierre { get; set; }

    }
}
