using Infrastructure.EntityFramework.ReadModel.Condominios;
using Infrastructure.EntityFramework.ReadModel.Turnos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.AreasComunes
{

    internal class AreaComunReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CapacidadMaxima{ get; set; }
        public string Estado { get; set; }
        public DateTime FinCierre { get; set; }
        public TurnoReadModel Turno { get; set; }
        public Guid TurnoId { get;  set; }
        public CondominioReadModel Condominio { get; set; }
        public Guid CondominioId { get; set; }
        public bool Eliminado { get; set; }

    }
}
