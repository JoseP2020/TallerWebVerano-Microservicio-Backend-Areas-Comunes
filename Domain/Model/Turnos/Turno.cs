using Shared.Core;

namespace Domain.Model.Turnos
{
    public class Turno:AggregateRoot<Guid>
    {
        public TimeOnly Inicio { get; private set; }
        public TimeOnly Fin { get; private set; }
        public Turno(TimeOnly inicio, TimeOnly fin)
        {
            verificarHora(inicio, fin);

            Id = Guid.NewGuid();
            Inicio = inicio; 
            Fin = fin;
               
        }
        private void verificarHora(TimeOnly inicio, TimeOnly fin)
        {
            if (fin < inicio.AddHours(1))
            {
                throw new BussinessRuleValidationException("La hora de fin debe ser al menos 1 hora después de la fecha de inicio.");
            }
        }

        public Turno() { }
    }
}
