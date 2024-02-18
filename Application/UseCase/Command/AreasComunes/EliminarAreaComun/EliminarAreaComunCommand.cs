using MediatR;

namespace Application.UseCase.Command.AreasComunes.EliminarAreaComun
{

    public record EliminarAreaComunCommand : IRequest<Guid>
    {
        public Guid AreaComunId { get; set; }

    }
}
