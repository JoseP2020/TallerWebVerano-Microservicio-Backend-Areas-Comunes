using Domain.Repository.Residentes;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Residentes.EditarResidente
{
    public class EditarResidenteHandler : IRequestHandler<EditarResidenteCommand, Guid>
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditarResidenteHandler(IResidenteRepository residenteRepository, IUnitOfWork unitOfWort)
        {
            _residenteRepository = residenteRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EditarResidenteCommand request, CancellationToken cancellationToken)
        {
            var residente = await _residenteRepository.FindByIdAsync(request.ResidenteId);

            if (residente == null)
            {
                throw new BussinessRuleValidationException("Residente no encontrado");
            }

            residente.editarResidente(request.Nombre, residente.Deudor);

            await _residenteRepository.UpdateAsync(residente);
            await _unitOfWork.Commit();
            return residente.Id;
        }
    }
}
