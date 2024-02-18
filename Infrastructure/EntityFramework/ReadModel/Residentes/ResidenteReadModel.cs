using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Residentes
{
    internal class ResidenteReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool Deudor { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

    }
}
