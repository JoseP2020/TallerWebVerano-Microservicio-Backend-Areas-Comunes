using Domain.Repository.Condominios;
using Domain.Repository.Turnos;
using MediatR;
using Shared.Core;

namespace Application.UseCase.Command.Condominios.EliminarCondominio
{
    public class EliminarCondominioHandler : IRequestHandler<EliminarCondominioCommand, Guid>
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarCondominioHandler(ITurnoRepository turnoRepository, ICondominioRepository condominioRepository, IUnitOfWork unitOfWort)
        {
            _condominioRepository = condominioRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarCondominioCommand request, CancellationToken cancellationToken)
        {
            var condominio = await _condominioRepository.FindByIdAsync(request.CondominioId);

            if (condominio == null)
            {
                throw new BussinessRuleValidationException("Condominio no encontrado");
            }

            condominio.delete();
            await _condominioRepository.UpdateAsync(condominio);
            await _unitOfWork.Commit();
            return condominio.Id;
        }
    }
}
