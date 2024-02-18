using Domain.Model.Turnos;

namespace Domain.Factory.Turnos
{

    public interface ITurnoFactory
    {
        Turno Crear(TimeOnly inicio, TimeOnly fin);
    }
}
