using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Turnos.EliminarTurno
{
    public class EliminarTurnoHandler : IRequestHandler<EliminarTurnoCommand, Guid>
    {
        private readonly ITurnoRepository _turnoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarTurnoHandler(ITurnoRepository turnoRepository, IUnitOfWork unitOfWort)
        {
            _turnoRepository = turnoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarTurnoCommand request, CancellationToken cancellationToken)
        {
            var turno = await _turnoRepository.FindByIdAsync(request.TurnoId);

            if (turno == null)
            {
                throw new BussinessRuleValidationException("Turno no encontrado");
            }

            turno.delete();
            await _turnoRepository.UpdateAsync(turno);
            await _unitOfWork.Commit();
            return turno.Id;
        }
    }
}
