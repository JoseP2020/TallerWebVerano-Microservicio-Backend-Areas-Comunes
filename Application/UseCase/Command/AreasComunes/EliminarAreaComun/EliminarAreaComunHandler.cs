using Domain.Factory.AreasComunes;
using Domain.Repository.AreasComunes;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.AreasComunes.EliminarAreaComun
{
    public class EliminarAreaComunHandler : IRequestHandler<EliminarAreaComunCommand, Guid>
    {
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarAreaComunHandler(ITurnoRepository turnoRepository, IAreaComunRepository areaComunRepository, IAreaComunFactory areaComunFactory, IUnitOfWork unitOfWort)
        {
            _areaComunRepository = areaComunRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarAreaComunCommand request, CancellationToken cancellationToken)
        {
            var area = await _areaComunRepository.FindByIdAsync(request.AreaComunId);

            if (area == null)
            {
                throw new BussinessRuleValidationException("Area no encontrada");
            }

            area.delete();
            await _areaComunRepository.UpdateAsync(area);
            await _unitOfWork.Commit();
            return area.Id;
        }
    }
}
