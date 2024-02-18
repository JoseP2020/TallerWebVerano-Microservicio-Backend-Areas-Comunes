using Domain.Model.Residentes;
using Domain.Repository.Residentes;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Residentes
{
    internal class ResidenteRepository : IResidenteRepository
    {
        private readonly WriteDbContext _context;

        public ResidenteRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Residente obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Residente?> FindByIdAsync(Guid id)
        {
            return await _context.Residente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Residente obj)
        {
            _context.Residente.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Residente obj)
        {
            _context.Residente.Update(obj);
            return Task.CompletedTask;
        }

    }
}
