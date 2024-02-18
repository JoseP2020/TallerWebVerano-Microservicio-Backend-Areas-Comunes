using Domain.Factory.Residentes;
using Domain.Repository.Residentes;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Residentes.CrearResidente
{
    public class CrearResidenteHandler : IRequestHandler<CrearResidenteCommand, Guid>
    {
        private readonly IResidenteRepository _residenteRepository;
        private readonly IResidenteFactory _residenteFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearResidenteHandler(IResidenteRepository residenteRepository, IResidenteFactory residenteFactory, IUnitOfWork unitOfWort)
        {
            _residenteRepository = residenteRepository;
            _residenteFactory = residenteFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearResidenteCommand request, CancellationToken cancellationToken)
        {
            var residente = _residenteFactory.Crear(request.Nombre);

            await _residenteRepository.CreateAsync(residente);
            await _unitOfWork.Commit();
            return residente.Id;
        }
    }
}
