using Domain.Factory.Reservas;
using Domain.Repository.Reservas;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Reservas.MandarAEspera
{
    public class MandarAEsperaHandler : IRequestHandler<MandarAEsperaCommand, Guid>
    {
        private readonly IReservaRepository _reservaComunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MandarAEsperaHandler(ITurnoRepository turnoRepository, IReservaRepository reservaComunRepository, IReservaFactory reservaComunFactory, IUnitOfWork unitOfWort)
        {
            _reservaComunRepository = reservaComunRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(MandarAEsperaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await _reservaComunRepository.FindByIdAsync(request.ReservaId);

            if (reserva == null)
            {
                throw new BussinessRuleValidationException("Area no encontrada");
            }

            reserva.mandarAEspera();
            await _unitOfWork.Commit();
            return reserva.Id;
        }
    }
}
