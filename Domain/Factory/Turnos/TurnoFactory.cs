using Domain.Model.Turnos;

namespace Domain.Factory.Turnos
{
    public class TurnoFactory : ITurnoFactory
    {
        public Turno Crear(TimeOnly inicio, TimeOnly fin)
        {
            return new Turno(inicio, fin);
        }
    }
}
