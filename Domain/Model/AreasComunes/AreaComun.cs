using Domain.ValueObjects;
using Shared.Core;
using Shared.ValueObjects;

namespace Domain.Model.AreasComunes
{
    public class AreaComun : AggregateRoot<Guid>
    {
        public Guid TurnoId { get; private set; }
        public Guid CondominioId { get; private set; }
        public NombreAreaComunValue Nombre { get; private set; }
        public DescripcionValue Descripcion { get; private set; }
        public CantidadValue CapacidadMaxima { get; private set; }
        public NombreAreaComunValue Estado { get; private set; }
        public DateTime FinCierre { get; private set; }

        public AreaComun(Guid condominioId, Guid turnoId, string nombre, string descripcion, int capacidadMaxima, string estado)
        {
            if (condominioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El condominioId es inválido.");
            }

            if (turnoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El turnoId es inválido.");
            }

            Id = Guid.NewGuid();
            CondominioId = condominioId;
            TurnoId = turnoId;
            Nombre = nombre;
            Descripcion = descripcion;
            CapacidadMaxima = capacidadMaxima;
            Estado = estado;
            FinCierre = DateTime.MinValue;
        }

        public AreaComun() { }

        public void editarAreaComunFinCierre(Guid condominioId, Guid turnoId, string nombre, string descripcion, int capacidadMaxima, string estado, DateTime finCierre)
        {
            if (condominioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El condominioId es inválido.");
            }

            if (turnoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El turnoId es inválido.");
            }

            verificarFechas(finCierre);
            
            FinCierre = finCierre;
            CondominioId = condominioId;
            TurnoId = turnoId;
            Nombre = nombre;
            Descripcion = descripcion;
            CapacidadMaxima = capacidadMaxima;
            Estado = estado;
        }

        public void editarAreaComun(Guid condominioId, Guid turnoId, string nombre, string descripcion, int capacidadMaxima, string estado)
        {
            if (condominioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El condominioId es inválido.");
            }

            if (turnoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El turnoId es inválido.");
            }
            CondominioId = condominioId;
            TurnoId = turnoId;
            Nombre = nombre;
            Descripcion = descripcion;
            CapacidadMaxima = capacidadMaxima;
            Estado = estado;
        }

        private void verificarFechas(DateTime fin)
        {
            if (fin < DateTime.Now.AddHours(1))
            {
                throw new BussinessRuleValidationException("La fecha de fin cierre debe ser al menos 1 hora después de ahora mismo.");
            }
        }
        public void Inhabilitar()
        {
            Estado = "No Disponible";
        }
    }
}
