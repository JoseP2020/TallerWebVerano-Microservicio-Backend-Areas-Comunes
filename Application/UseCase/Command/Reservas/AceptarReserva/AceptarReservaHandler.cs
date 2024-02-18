using Domain.Factory.Reservas;
using Domain.Repository.Reservas;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Reservas.AceptarReserva
{
    public class AceptarReservaHandler : IRequestHandler<AceptarReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaComunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AceptarReservaHandler(ITurnoRepository turnoRepository, IReservaRepository reservaComunRepository, IReservaFactory reservaComunFactory, IUnitOfWork unitOfWort)
        {
            _reservaComunRepository = reservaComunRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AceptarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await _reservaComunRepository.FindByIdAsync(request.ReservaId);

            if (reserva == null)
            {
                throw new BussinessRuleValidationException("Area no encontrada");
            }

            reserva.aceptar();
            await _unitOfWork.Commit();
            return reserva.Id;
        }
    }
}
