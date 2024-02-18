using Application.Dto.AreasComunes;
using Application.Dto.Condominios;
using Application.Dto.Turnos;
using Application.UseCase.Query.AreasComunes;
using Domain.Model.Turnos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.AreasComunes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Query.AreasComunes
{
    internal class GetListaAreasComunesHandler : IRequestHandler<GetListaAreasComunesQuery, IEnumerable<AreaComunDto>>
    {
        private readonly DbSet<AreaComunReadModel> areaComun;
        public GetListaAreasComunesHandler(ReadDbContext dbContext)
        {
            areaComun = dbContext.AreaComun;
        }
        public async Task<IEnumerable<AreaComunDto>> Handle(GetListaAreasComunesQuery request, CancellationToken cancellationToken)
        {
            var query = areaComun.AsNoTracking().Include(o => o.Turno).Where(area=>area.Eliminado==false).AsQueryable();

            var lista = await query.Select(areaComun => new AreaComunDto
            {
                Id = areaComun.Id,
                Nombre = areaComun.Nombre,
                Descripcion = areaComun.Descripcion,
                CapacidadMaxima = areaComun.CapacidadMaxima,
                Estado = areaComun.Estado,
                FinCierre = areaComun.FinCierre,
                Turno = new TurnoDto
                {
                    Id = areaComun.Turno.Id,
                    Inicio = areaComun.Turno.Inicio,
                    Fin = areaComun.Turno.Fin,
                },
                Condominio = new CondominioDto
                {
                    Id = areaComun.Condominio.Id,
                    Nombre = areaComun.Condominio.Nombre
                }
            }).ToListAsync();

            return lista;
        }
    }
}
