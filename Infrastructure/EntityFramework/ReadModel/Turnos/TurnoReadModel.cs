using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Turnos
{

    internal class TurnoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public TimeOnly Inicio { get; set; }
        public TimeOnly Fin { get; set; }
        public bool Eliminado { get; set; }

    }
}
