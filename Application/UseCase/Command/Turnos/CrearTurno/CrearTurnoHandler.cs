using Domain.Factory.Turnos;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Turnos.CrearTurno
{
    public class CrearTurnoHandler : IRequestHandler<CrearTurnoCommand, Guid>
    {
        private readonly ITurnoRepository _turnoRepository;
        private readonly ITurnoFactory _turnoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTurnoHandler(ITurnoRepository turnoRepository, ITurnoFactory turnoFactory, IUnitOfWork unitOfWort)
        {
            _turnoRepository = turnoRepository;
            _turnoFactory = turnoFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearTurnoCommand request, CancellationToken cancellationToken)
        {
            
            var inicio = TimeOnly.Parse(request.Inicio);
            var fin = TimeOnly.Parse(request.Fin);

            var turno = _turnoFactory.Crear(inicio, fin);

            await _turnoRepository.CreateAsync(turno);
            await _unitOfWork.Commit();
            return turno.Id;
        }
    }
}
