using Domain.Repository.Residentes;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Residentes.EliminarResidente
{
    public class EliminarResidenteHandler : IRequestHandler<EliminarResidenteCommand, Guid>
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarResidenteHandler(ITurnoRepository turnoRepository, IResidenteRepository residenteRepository, IUnitOfWork unitOfWort)
        {
            _residenteRepository = residenteRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarResidenteCommand request, CancellationToken cancellationToken)
        {
            var residente = await _residenteRepository.FindByIdAsync(request.ResidenteId);

            if (residente == null)
            {
                throw new BussinessRuleValidationException("Residente no encontrado");
            }

            residente.delete();
            await _residenteRepository.UpdateAsync(residente);
            await _unitOfWork.Commit();
            return residente.Id;
        }
    }
}
