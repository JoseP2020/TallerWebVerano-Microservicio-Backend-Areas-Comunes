using Domain.Model.AreasComunes;
using Domain.Model.Reservas;
using Shared.Core;

namespace Domain.Repository.Reservas
{
    public interface IReservaRepository : IRepository<Reserva, Guid>
    {
        Task UpdateAsync(Reserva obj);
        Task RemoveAsync(Reserva obj);
        Task<bool> ExisteSolapamiento(Guid areaComunId, DateTime inicio, DateTime fin);

        Task<bool> ExisteSolapamientoActualizar(Guid areaComunId, Guid reservaId, DateTime inicio, DateTime fin);
    }
}

