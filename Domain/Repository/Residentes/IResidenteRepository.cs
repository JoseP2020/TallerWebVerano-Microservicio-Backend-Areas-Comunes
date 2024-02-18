using Domain.Model.Reservas;
using Domain.Model.Residentes;
using Shared.Core;

namespace Domain.Repository.Residentes
{
    public interface IResidenteRepository : IRepository<Residente, Guid>
    {
        Task UpdateAsync(Residente obj);
        Task RemoveAsync(Residente obj);
    }
}

