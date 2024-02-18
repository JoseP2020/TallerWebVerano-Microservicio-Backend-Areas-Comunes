using MediatR;

namespace Application.UseCase.Command.AreasComunes.InhabilitarAreaComun
{

    public record InhabilitarAreaComunCommand : IRequest<Guid>
    {
        public Guid AreaComunId { get; set; }

    }
}
