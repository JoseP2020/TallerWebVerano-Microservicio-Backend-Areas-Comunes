using Domain.Model.Condominios;
using Shared.Core;

namespace Domain.Repository.Condominios
{

    public interface ICondominioRepository : IRepository<Condominio, Guid>
    {
        Task UpdateAsync(Condominio obj);
        Task RemoveAsync(Condominio obj);
    }
}
