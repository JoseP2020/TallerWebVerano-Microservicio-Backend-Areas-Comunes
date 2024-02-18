using Domain.Factory.Reservas;
using Domain.Model.Residentes;
using Domain.Repository.AreasComunes;
using Domain.Repository.Reservas;
using Domain.Repository.Residentes;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Reservas.EditarReserva
{
    public class EditarReservaHandler : IRequestHandler<EditarReservaCommand, Guid>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly IResidenteRepository _residenteRepository;
        private readonly ITurnoRepository _turnoRepository;
        private readonly IReservaFactory _reservaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public EditarReservaHandler(ITurnoRepository turnoRepository, IAreaComunRepository areaComunRepository, IResidenteRepository residenteRepository, IReservaRepository reservaRepository, IReservaFactory reservaFactory, IUnitOfWork unitOfWort)
        {
            _turnoRepository = turnoRepository;
            _areaComunRepository = areaComunRepository;
            _residenteRepository = residenteRepository;
            _reservaRepository = reservaRepository;
            _reservaFactory = reservaFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EditarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await _reservaRepository.FindByIdAsync(request.ReservaId);

            if (reserva == null)
            {
                throw new BussinessRuleValidationException("Reserva no encontrada");
            }

            var areaComun = await _areaComunRepository.FindByIdAsync(request.AreaComunId);

            if (areaComun == null)
            {
                throw new BussinessRuleValidationException("AreaComun no encontrada");
            }

            var residente = await _residenteRepository.FindByIdAsync(request.ResidenteId);

            if (residente == null)
            {
                throw new BussinessRuleValidationException("Residente no encontrado");
            }

            await validarResidente(residente);
            await validarTurno(request, areaComun.TurnoId, _turnoRepository);
            await validarSolapamientoReservas(request, areaComun.Id, _reservaRepository);

            reserva.editarReserva(areaComun.Id, residente.Id, request.Inicio, request.Fin);

            await _reservaRepository.UpdateAsync(reserva);
            await _unitOfWork.Commit();
            return reserva.Id;
        }

        private async Task validarResidente(Residente residente)
        {
            if (residente.Deudor)
            {
                throw new BussinessRuleValidationException("El residente es deudor");
            }
        }

        private async Task validarTurno(EditarReservaCommand request, Guid turnoId, ITurnoRepository turnoRepository)
        {
            var turno = await turnoRepository.FindByIdAsync(turnoId);

            TimeOnly inicioTurno = turno.Inicio;
            TimeOnly finTurno = turno.Fin;

            TimeOnly inicioReserva = TimeOnly.FromDateTime(request.Inicio);
            TimeOnly finReserva = TimeOnly.FromDateTime(request.Fin);


            if (inicioReserva < inicioTurno || finReserva > finTurno)
            {
                throw new BussinessRuleValidationException("Las horas de la reserva deben estar dentro del rango del turno.");
            }
        }

        private async Task validarSolapamientoReservas(EditarReservaCommand request, Guid areaComunId, IReservaRepository reservaRepository)
        {
            var existeSolapamiento = await reservaRepository.ExisteSolapamiento(areaComunId, request.Inicio, request.Fin);
            if (existeSolapamiento)
            {
                throw new BussinessRuleValidationException("Ya hay otra reserva en el mismo horario y área común.");
            }
        }
    }
}
