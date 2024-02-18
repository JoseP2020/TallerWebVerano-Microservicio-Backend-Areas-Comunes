using Application.Dto.Residentes;
using Application.UseCase.Query.Residentes;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Residentes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Query.Residentes
{
    internal class GetListaResidentesHandler : IRequestHandler<GetListaResidentesQuery, IEnumerable<ResidenteDto>>
    {
        private readonly DbSet<ResidenteReadModel> residente;
        public GetListaResidentesHandler(ReadDbContext dbContext)
        {
            residente = dbContext.Residente;
        }
        public async Task<IEnumerable<ResidenteDto>> Handle(GetListaResidentesQuery request, CancellationToken cancellationToken)
        {
            var query = residente.AsNoTracking().Where(residente => residente.Eliminado == false).AsQueryable();

            var lista = await query.Select(residente => new ResidenteDto
            {
                Id = residente.Id,
                Nombre = residente.Nombre,
                Deudor = residente.Deudor,
            }).ToListAsync();

            return lista;
        }
    }
}
