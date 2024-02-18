using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.Residentes
{
    public class Residente:AggregateRoot<Guid>
    {
        public NombrePersonaValue Nombre { get; private set; }
        public bool Deudor { get; private set; }
        public Residente(string nombre)
        {

            Id = Guid.NewGuid();
            Nombre = nombre;
            Deudor = false;
        }
        public Residente (){ }
        public void editarResidente (string nombre, bool deudor)
        {
            Nombre = nombre;
            Deudor = deudor;
        }
    }
} 
