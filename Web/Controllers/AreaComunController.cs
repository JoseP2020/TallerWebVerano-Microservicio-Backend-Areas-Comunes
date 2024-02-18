using Application.UseCase.Command.AreasComunes.CrearAreaComun;
using Application.UseCase.Command.AreasComunes.EditarAreaComun;
using Application.UseCase.Command.AreasComunes.EliminarAreaComun;
using Application.UseCase.Command.AreasComunes.InhabilitarAreaComun;
using Application.UseCase.Query.AreasComunes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/areaComun")]
    [ApiController]
    public class AreaComunController : ControllerBase
    {
        private readonly ILogger<AreaComunController> _logger;
        private readonly IMediator _mediator;

        public AreaComunController(IMediator mediator, ILogger<AreaComunController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearAreaComun([FromBody] CrearAreaComunCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el area comun");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarAreaComun([FromBody] EliminarAreaComunCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el area comun");
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetListaAreasComunesQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditarAreaComun([FromBody] EditarAreaComunCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al editar el area comun");
                return BadRequest();
            }
        }
        [HttpPatch]
        public async Task<IActionResult> InhabilitarAreaComun([FromBody] InhabilitarAreaComunCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al inhabilitar el area comun");
                return BadRequest();
            }
        }
    }
}
