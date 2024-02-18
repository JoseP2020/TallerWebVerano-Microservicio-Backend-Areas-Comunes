using Domain.Model.AreasComunes;
using Domain.Repository.AreasComunes;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.AreasComunes
{
    internal class AreaComunRepository : IAreaComunRepository
    {
        private readonly WriteDbContext _context;

        public AreaComunRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(AreaComun obj)
        {
            await _context.AreaComun.AddAsync(obj);
        }

        public async Task<AreaComun?> FindByIdAsync(Guid id)
        {
            return await _context.AreaComun
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(AreaComun obj)
        {
            _context.AreaComun.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(AreaComun obj)
        {
            _context.AreaComun.Update(obj);
            return Task.CompletedTask;
        }

    }
}
