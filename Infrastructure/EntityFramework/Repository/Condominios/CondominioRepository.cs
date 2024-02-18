using Domain.Model.Condominios;
using Domain.Repository.Condominios;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Condominios
{
    internal class CondominioRepository : ICondominioRepository
    {
        private readonly WriteDbContext _context;

        public CondominioRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Condominio obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Condominio?> FindByIdAsync(Guid id)
        {
            return await _context.Condominio.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Condominio obj)
        {
            _context.Condominio.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Condominio obj)
        {
            _context.Condominio.Update(obj);
            return Task.CompletedTask;
        }

    }
}
