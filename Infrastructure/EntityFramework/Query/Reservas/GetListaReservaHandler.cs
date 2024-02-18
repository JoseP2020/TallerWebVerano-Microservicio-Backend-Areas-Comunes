using Application.Dto.AreasComunes;
using Application.Dto.Condominios;
using Application.Dto.Reservas;
using Application.Dto.Residentes;
using Application.Dto.Turnos;
using Application.UseCase.Query.Reservas;
using Domain.Model.AreasComunes;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Reservas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Query.Reservas
{
    internal class GetListaReservasHandler : IRequestHandler<GetListaReservasQuery, IEnumerable<ReservaDto>>
    {
        private readonly DbSet<ReservaReadModel> reserva;
        public GetListaReservasHandler(ReadDbContext dbContext)
        {
            reserva = dbContext.Reserva;
        }
        public async Task<IEnumerable<ReservaDto>> Handle(GetListaReservasQuery request, CancellationToken cancellationToken)
        {
            var query = reserva.AsNoTracking().Where(reserva => reserva.Eliminado == false).AsQueryable();

            var lista = await query.Select(reserva => new ReservaDto
            {
                Id = reserva.Id,
                Estado = reserva.Estado,
                Inicio = reserva.Inicio,
                Fin = reserva.Fin,
                AreaComun = new AreaComunDto
                {
                    Id = reserva.AreaComun.Id,
                    Nombre = reserva.AreaComun.Nombre,
                    Descripcion = reserva.AreaComun.Descripcion,
                    CapacidadMaxima = reserva.AreaComun.CapacidadMaxima,
                    Estado = reserva.AreaComun.Estado,
                    Turno = new TurnoDto
                    {
                        Id = reserva.AreaComun.Turno.Id,
                        Inicio = reserva.AreaComun.Turno.Inicio,
                        Fin = reserva.AreaComun.Turno.Fin,
                    },
                    Condominio = new CondominioDto
                    {
                        Id = reserva.AreaComun.Condominio.Id,
                        Nombre = reserva.AreaComun.Condominio.Nombre
                    }
                },
                Residente = new ResidenteDto
                {
                    Id = reserva.Residente.Id,
                    Nombre = reserva.Residente.Nombre
                }

            }).ToListAsync();

            return lista;
        }
    }
}
