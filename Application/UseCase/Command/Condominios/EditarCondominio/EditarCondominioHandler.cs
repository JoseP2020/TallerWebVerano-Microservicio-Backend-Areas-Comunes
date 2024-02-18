using Domain.Repository.Condominios;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Condominios.EditarCondominio
{
    public class EditarCondominioHandler : IRequestHandler<EditarCondominioCommand, Guid>
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditarCondominioHandler(ICondominioRepository condominioRepository, IUnitOfWork unitOfWort)
        {
            _condominioRepository = condominioRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EditarCondominioCommand request, CancellationToken cancellationToken)
        {
            var condominio = await _condominioRepository.FindByIdAsync(request.CondominioId);

            if (condominio == null)
            {
                throw new BussinessRuleValidationException("Condominio no encontrado");
            }

            condominio.editarCondominio(request.Nombre);

            await _condominioRepository.UpdateAsync(condominio);
            await _unitOfWork.Commit();
            return condominio.Id;
        }
    }
}
