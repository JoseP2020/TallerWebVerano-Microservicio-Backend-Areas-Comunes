using Domain.Factory.AreasComunes;
using Domain.Model.AreasComunes;
using Domain.Repository.AreasComunes;
using Domain.Repository.Condominios;
using Domain.Repository.Reservas;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.AreasComunes.EditarAreaComun
{
    public class EditarAreaComunHandler : IRequestHandler<EditarAreaComunCommand, Guid>
    {
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly ITurnoRepository _turnoRepository;
        private readonly ICondominioRepository _condominioRepository;
        private readonly IAreaComunFactory _areaComunFactory;
        private readonly IUnitOfWork _unitOfWork;

        public EditarAreaComunHandler(IReservaRepository reservaRepository, ICondominioRepository condominioRepository, ITurnoRepository turnoRepository, IAreaComunRepository areaComunRepository, IAreaComunFactory areaComunFactory, IUnitOfWork unitOfWort)
        {
            _reservaRepository = reservaRepository;
            _condominioRepository = condominioRepository;
            _turnoRepository = turnoRepository;
            _areaComunRepository = areaComunRepository;
            _areaComunFactory = areaComunFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EditarAreaComunCommand request, CancellationToken cancellationToken)
        {
            var condominio = await _condominioRepository.FindByIdAsync(request.CondominioId);

            if (condominio == null)
            {
                throw new BussinessRuleValidationException("Condominio no encontrado");
            }

            var area = await _areaComunRepository.FindByIdAsync(request.AreaComunId);

            if (area == null)
            {
                throw new BussinessRuleValidationException("Area no encontrada");
            }

            var turno = await _turnoRepository.FindByIdAsync(request.TurnoId);

            if (turno == null)
            {
                throw new BussinessRuleValidationException("Turno no encontrado");
            }

            if(request.FinCierre != null)
            {
                var existeSolapamiento = await _reservaRepository.ExisteSolapamiento(area.Id, DateTime.Now, (DateTime)request.FinCierre);
                if (existeSolapamiento)
                {
                    throw new BussinessRuleValidationException("Ya hay otra reserva en el mismo horario y área común.");
                }
                area.editarAreaComunFinCierre(request.CondominioId, request.TurnoId, request.Nombre, request.Descripcion, request.CapacidadMaxima, request.Estado, (DateTime)request.FinCierre);
            }
            else
            {
                area.editarAreaComun(request.CondominioId, request.TurnoId, request.Nombre, request.Descripcion, request.CapacidadMaxima, request.Estado);
            }


            await _areaComunRepository.UpdateAsync(area);
            await _unitOfWork.Commit();
            return area.Id;
        }
    }
}
