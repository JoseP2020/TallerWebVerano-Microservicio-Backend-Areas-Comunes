using Application.UseCase.Command.Turnos.CrearTurno;
using Application.UseCase.Command.Turnos.EliminarTurno;
using Application.UseCase.Query.Turnos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/turno")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ILogger<TurnoController> _logger;
        private readonly IMediator _mediator;

        public TurnoController(IMediator mediator, ILogger<TurnoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTurno([FromBody] CrearTurnoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el turno");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetListaTurnosQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarTurno([FromBody] EliminarTurnoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el turno");
                return BadRequest();
            }
        }
    }
}
