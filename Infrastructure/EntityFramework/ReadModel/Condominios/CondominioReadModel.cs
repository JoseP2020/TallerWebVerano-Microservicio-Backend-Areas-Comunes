using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Condominios
{
    internal class CondominioReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

    }
}
