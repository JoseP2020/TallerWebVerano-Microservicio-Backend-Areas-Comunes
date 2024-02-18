using Shared.Core;
using System.Diagnostics;

namespace Domain.Model.Reservas
{
    public class Reserva: AggregateRoot<Guid>
    {
        public Guid AreaComunId { get; private set; }
        public Guid ResidenteId { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fin { get; private set; }
        public EstadoReserva Estado { get; private set; }
        public Reserva (Guid areaComunId, Guid residenteId,DateTime inicio, DateTime fin)
        {
            if (areaComunId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El areaComunId es inválido.");
            }
            if (residenteId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El residenteId es inválido.");
            }

            verificarFechas(inicio, fin);

            Id = Guid.NewGuid();
            AreaComunId = areaComunId;
            ResidenteId = residenteId;
            Inicio = inicio;
            Fin = fin;
            Estado = EstadoReserva.Solicitado;
        }
        public Reserva() { }

        public void editarReserva(Guid areaComunId, Guid residenteId, DateTime inicio, DateTime fin)
        {

            if (areaComunId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El areaComunId es inválido.");
            }

            if (residenteId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El residenteId es inválido.");
            }

            verificarFechas(inicio, fin);
            
            AreaComunId = areaComunId;
            ResidenteId = residenteId;
            Inicio = inicio;
            Fin = fin;
        }

        private void verificarFechas(DateTime inicio, DateTime fin)
        {
            if (fin < inicio.AddHours(1))
            {
                throw new BussinessRuleValidationException("La fecha de fin debe ser al menos 1 hora después de la fecha de inicio.");
            }

            if (inicio < DateTime.Now)
            {
                throw new BussinessRuleValidationException("La fecha de inicio debe ser a partir de ahora.");
            }
        }
        public void aceptar()
        {
            if (Estado == EstadoReserva.Solicitado || Estado == EstadoReserva.Espera)
            {
                Estado = EstadoReserva.Aceptado;
            }
            else
            {
                throw new BussinessRuleValidationException($"La reserva no puede ser aceptada. Estado actual: {Estado}");
            }
        }

        public void mandarAEspera()
        {
            if (Estado == EstadoReserva.Solicitado)
            {
                Estado = EstadoReserva.Espera;
            }
            else
            {
                throw new BussinessRuleValidationException($"La reserva no puede ser mandada a espera. Estado actual: {Estado}");
            }
        }

    }
}
