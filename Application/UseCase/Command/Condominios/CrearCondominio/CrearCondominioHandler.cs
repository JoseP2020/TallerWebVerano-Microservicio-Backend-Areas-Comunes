using Domain.Factory.Condominios;
using Domain.Repository.Condominios;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Condominios.CrearCondominio
{
    public class CrearCondominioHandler : IRequestHandler<CrearCondominioCommand, Guid>
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly ICondominioFactory _condominioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCondominioHandler(ICondominioRepository condominioRepository, ICondominioFactory condominioFactory, IUnitOfWork unitOfWort)
        {
            _condominioRepository = condominioRepository;
            _condominioFactory = condominioFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearCondominioCommand request, CancellationToken cancellationToken)
        {
            var condominio = _condominioFactory.Crear(request.Nombre);

            await _condominioRepository.CreateAsync(condominio);
            await _unitOfWork.Commit();
            return condominio.Id;
        }
    }
}
