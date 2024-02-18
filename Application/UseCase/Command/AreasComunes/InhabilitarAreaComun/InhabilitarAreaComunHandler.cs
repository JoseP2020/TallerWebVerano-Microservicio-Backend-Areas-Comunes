using Application.UseCase.Command.AreasComunes.InhabilitarAreaComun;
using Domain.Repository.AreasComunes;
using MediatR;
using Shared.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCase.Command.AreasComunes.InhabilitarAreaComun
{
    public class InhabilitarAreaComunHandler : IRequestHandler<InhabilitarAreaComunCommand, Guid>
    {
        private readonly IAreaComunRepository _areaComunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InhabilitarAreaComunHandler(IAreaComunRepository areaComunRepository, IUnitOfWork unitOfWork)
        {
            _areaComunRepository = areaComunRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(InhabilitarAreaComunCommand request, CancellationToken cancellationToken)
        {
            var area = await _areaComunRepository.FindByIdAsync(request.AreaComunId);

            if (area == null)
            {
                throw new BussinessRuleValidationException("Área no encontrada");
            }

            // Utiliza el método Inhabilitar en el modelo de dominio
            area.Inhabilitar();

            // No elimines el área, solo actualiza su estado

            // Guarda los cambios (esto puede variar según cómo implementes tu persistencia)
            await _unitOfWork.Commit();

            return area.Id;
        }
    }
}
