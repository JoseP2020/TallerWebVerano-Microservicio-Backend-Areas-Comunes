using Domain.Model.Residentes;
using Domain.Model.Turnos;
using Shared.Core;

namespace Domain.Repository.Turnos
{
    public interface ITurnoRepository : IRepository<Turno, Guid>
    {
        Task UpdateAsync(Turno obj);
        Task RemoveAsync(Turno obj);
    }
}

