using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.Condominios
{
    public class Condominio : AggregateRoot<Guid>
    {
        public NombreCondominioValue Nombre { get; private set; }

        public Condominio(string nombre)
        {

            Id = Guid.NewGuid();
            Nombre = nombre;
        }
        public Condominio() { }
        public void editarCondominio(string nombre)
        {
            Nombre = nombre;
        }
    }
}
