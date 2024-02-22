using Application.Dto.AreasComunes;
using Application.Dto.Residentes;

namespace Application.Dto.Reservas
{
    public class ReservaDto
    {
        public Guid Id { get; set; }
        public ResidenteDto Residente { get; set; }
        public AreaComunDto AreaComun { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Estado { get; set; }
        public bool Eliminado { get; set; }
    }
}
