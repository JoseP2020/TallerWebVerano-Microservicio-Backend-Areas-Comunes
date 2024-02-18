using Domain.Model.Reservas;

namespace Domain.Factory.Reservas
{
    public class ReservaFactory : IReservaFactory
    {
 
        public Reserva Crear(Guid areaComunId, Guid residenteId, DateTime inicio, DateTime fin)
        {
            return new Reserva(areaComunId, residenteId, inicio, fin);
        }
    }
}
