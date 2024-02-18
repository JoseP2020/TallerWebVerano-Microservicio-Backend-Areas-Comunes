using Domain.Factory.Reservas;
using Domain.Repository.Reservas;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Reservas.EliminarReserva
{
    public class EliminarReservaHandler : IRequestHandler<EliminarReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaComunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarReservaHandler(ITurnoRepository turnoRepository, IReservaRepository reservaComunRepository, IReservaFactory reservaComunFactory, IUnitOfWork unitOfWort)
        {
            _reservaComunRepository = reservaComunRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await _reservaComunRepository.FindByIdAsync(request.ReservaId);

            if (reserva == null)
            {
                throw new BussinessRuleValidationException("Area no encontrada");
            }

            reserva.delete();
            await _reservaComunRepository.UpdateAsync(reserva);
            await _unitOfWork.Commit();
            return reserva.Id;
        }
    }
}
