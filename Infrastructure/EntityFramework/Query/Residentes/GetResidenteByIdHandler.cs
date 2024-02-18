using Application.Dto.Residentes;
using Application.UseCase.Query.Residentes;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Residentes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    internal class GetResidenteByIdHandler : IRequestHandler<GetResidenteByIdQuery, List<ResidenteDto>>
    {
        private readonly DbSet<ResidenteReadModel> residentes;

        public GetResidenteByIdHandler(ReadDbContext dbContext)
        {
            residentes = dbContext.Residente;
        }

        public async Task<List<ResidenteDto>> Handle(GetResidenteByIdQuery request, CancellationToken cancellationToken)
        {
            var nombreResidente = await residentes.AsNoTracking()
                .Where(x => x.Nombre == request.Nombre)
                .Select(residente => new ResidenteDto
                {
                    Id = residente.Id,
                    Nombre = residente.Nombre,
                })
                .ToListAsync();

            return nombreResidente;
        }
    }
}
