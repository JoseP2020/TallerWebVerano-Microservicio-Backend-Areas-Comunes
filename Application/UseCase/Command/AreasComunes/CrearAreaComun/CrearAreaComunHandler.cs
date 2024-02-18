using Domain.Factory.AreasComunes;
using Domain.Repository.AreasComunes;
using Domain.Repository.Condominios;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.AreasComunes.CrearAreaComun
{
    public class CrearAreaComunHandler : IRequestHandler<CrearAreaComunCommand, Guid>
    {
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly ITurnoRepository _turnoRepository;
        private readonly ICondominioRepository _condominioRepository;
        private readonly IAreaComunFactory _areaComunFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearAreaComunHandler(ICondominioRepository condominioRepository, ITurnoRepository turnoRepository, IAreaComunRepository areaComunRepository, IAreaComunFactory areaComunFactory, IUnitOfWork unitOfWort)
        {
            _condominioRepository = condominioRepository;
            _turnoRepository = turnoRepository;
            _areaComunRepository = areaComunRepository;
            _areaComunFactory = areaComunFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearAreaComunCommand request, CancellationToken cancellationToken)
        {
            var condominio = await _condominioRepository.FindByIdAsync(request.CondominioId);

            if (condominio == null)
            {
                throw new BussinessRuleValidationException("Condominio no encontrado");
            }

            var turno = await _turnoRepository.FindByIdAsync(request.TurnoId);

            if (turno == null)
            {
                throw new BussinessRuleValidationException("Turno no encontrado");
            }

            var areaComun = _areaComunFactory.Crear(request.CondominioId, request.TurnoId, request.Nombre, request.Descripcion, request.CapacidadMaxima, request.Estado);
            await _areaComunRepository.CreateAsync(areaComun);
            await _unitOfWork.Commit();
            return areaComun.Id;
        }
    }
}
