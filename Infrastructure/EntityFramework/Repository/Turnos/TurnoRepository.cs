using Domain.Model.Turnos;
using Domain.Repository.Turnos;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Turnos
{
    internal class TurnoRepository : ITurnoRepository
    {
        private readonly WriteDbContext _context;

        public TurnoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Turno obj)
        {
            await _context.Turno.AddAsync(obj);
        }

        public async Task<Turno?> FindByIdAsync(Guid id)
        {
            return await _context.Turno.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Turno obj)
        {
            _context.Turno.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Turno obj)
        {
            _context.Turno.Update(obj);
            return Task.CompletedTask;
        }

    }
}
