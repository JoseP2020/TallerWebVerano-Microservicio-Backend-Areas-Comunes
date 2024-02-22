using Application.Dto.Reservas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Query.Reservas
    {
        public class GetReservasByIdQuery : IRequest<List<ReservaDto>>
        {
            public Guid ResidenteId { get; set; }

        }
    }