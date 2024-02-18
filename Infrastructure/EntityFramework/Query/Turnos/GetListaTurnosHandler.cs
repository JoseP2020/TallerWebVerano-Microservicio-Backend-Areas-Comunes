using Application.Dto.Turnos;
using Application.UseCase.Query.Turnos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Turnos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Query.Turnos
{
    internal class GetListaTurnosHandler : IRequestHandler<GetListaTurnosQuery, IEnumerable<TurnoDto>>
    {
        private readonly DbSet<TurnoReadModel> turnos;
        public GetListaTurnosHandler(ReadDbContext dbContext)
        {
            turnos = dbContext.Turno;
        }
        public async Task<IEnumerable<TurnoDto>> Handle(GetListaTurnosQuery request, CancellationToken cancellationToken)
        {
            var query = turnos.AsNoTracking().Where(turno => turno.Eliminado == false).AsQueryable();

            var lista = await query.Select(turno => new TurnoDto
            {
                Id = turno.Id,
                Inicio = turno.Inicio,
                Fin = turno.Fin,
            }).ToListAsync();

            return lista;
        }
    }
}
