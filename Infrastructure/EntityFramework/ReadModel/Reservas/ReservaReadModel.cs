
using Infrastructure.EntityFramework.ReadModel.AreasComunes;
using Infrastructure.EntityFramework.ReadModel.Residentes;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Reservas
{
    internal class ReservaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public AreaComunReadModel AreaComun { get; set; }
        public Guid AreaComunId { get; set; }
        public ResidenteReadModel Residente { get; set; }
        public Guid ResidenteId { get; set; }
        public bool Eliminado { get; set; }

    }
}

