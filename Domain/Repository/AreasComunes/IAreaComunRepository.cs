using Domain.Model.AreasComunes;
using Shared.Core;

namespace Domain.Repository.AreasComunes
{
    public interface IAreaComunRepository : IRepository<AreaComun, Guid>
    {
        Task UpdateAsync(AreaComun obj);
        Task RemoveAsync(AreaComun obj);
    }
}
