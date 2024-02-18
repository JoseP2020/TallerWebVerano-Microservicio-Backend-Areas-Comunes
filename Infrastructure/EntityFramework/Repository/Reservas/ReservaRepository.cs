using Domain.Model.AreasComunes;
using Domain.Model.Reservas;
using Domain.Repository.Reservas;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Reservas
{
    internal class ReservaRepository : IReservaRepository
    {
        private readonly WriteDbContext _context;

        public ReservaRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Reserva obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<bool> ExisteSolapamiento(Guid areaComunId, DateTime inicio, DateTime fin)
        {
            DateTime inicioUtc = inicio.ToUniversalTime();
            DateTime finUtc = fin.ToUniversalTime();

            return await _context.Reserva
                .AnyAsync(r =>
                    r.AreaComunId == areaComunId &&
                    (
                        (inicioUtc > r.Inicio && inicioUtc < r.Fin) ||
                        (finUtc > r.Inicio && finUtc < r.Fin) ||
                        (inicioUtc < r.Inicio && finUtc > r.Fin)
                    )
                );
        }

        public async Task<Reserva?> FindByIdAsync(Guid id)
        {
            return await _context.Reserva.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Reserva obj)
        {
            _context.Reserva.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Reserva obj)
        {
            _context.Reserva.Update(obj);
            return Task.CompletedTask;
        }

    }
}
