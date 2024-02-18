using Domain.Model.Reservas;

namespace Domain.Factory.Reservas
{
    public interface IReservaFactory
    {
        Reserva Crear(Guid areaComunId, Guid residenteId, DateTime inicio, DateTime fin);
    }
}
