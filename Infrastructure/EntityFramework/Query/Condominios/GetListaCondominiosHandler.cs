using Application.Dto.Condominios;
using Application.UseCase.Query.Condominios;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Condominios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Query.Condominios
{
    internal class GetListaCondominiosHandler : IRequestHandler<GetListaCondominiosQuery, IEnumerable<CondominioDto>>
    {
        private readonly DbSet<CondominioReadModel> condominio;
        public GetListaCondominiosHandler(ReadDbContext dbContext)
        {
            condominio = dbContext.Condominio;
        }
        public async Task<IEnumerable<CondominioDto>> Handle(GetListaCondominiosQuery request, CancellationToken cancellationToken)
        {
            var query = condominio.AsNoTracking().Where(condominio => condominio.Eliminado == false).AsQueryable();

            var lista = await query.Select(condominio => new CondominioDto
            {
                Id = condominio.Id,
                Nombre = condominio.Nombre
            }).ToListAsync();

            return lista;
        }
    }
}
