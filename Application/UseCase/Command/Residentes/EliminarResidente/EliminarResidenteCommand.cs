using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Residentes.EliminarResidente
{
    public record EliminarResidenteCommand : IRequest<Guid>
    {
        public Guid ResidenteId { get; set; }
    }
}
