using Application.Dto.AreasComunes;
using Application.Dto.Condominios;
using Application.Dto.Reservas;
using Application.Dto.Residentes;
using Application.Dto.Turnos;
using Application.UseCase.Query.Reservas;
using Domain.Model.Reservas;
using Domain.Model.Turnos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Reservas;
using Infrastructure.EntityFramework.ReadModel.Residentes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.Query.Reservas
{
    internal class GetReservaByIdHandler : IRequestHandler<GetReservasByIdQuery, List<ReservaDto>>
    {
        private readonly DbSet<ReservaReadModel> reservas;

        public GetReservaByIdHandler(ReadDbContext dbContext)
        {
            reservas = dbContext.Reserva;
        }

        public async Task<List<ReservaDto>> Handle(GetReservasByIdQuery request, CancellationToken cancellationToken)
        {
            var nombreResidente = await reservas.AsNoTracking()
                .Where(x => x.ResidenteId == request.ResidenteId)
                .Select(reserva => new ReservaDto
                {
                    Id = reserva.Id,
                    Residente = new ResidenteDto
                    {
                        Id = reserva.Residente.Id,
                        Nombre = reserva.Residente.Nombre,
                    },
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
                    Inicio = reserva.Inicio,
                    Fin = reserva.Fin,
                    Estado = reserva.Estado,
                    Eliminado = reserva.Eliminado
                })
                .ToListAsync();

            return nombreResidente;
        }
    }
}
