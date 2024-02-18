using Application.UseCase.Command.Residentes.CrearResidente;
using Application.UseCase.Command.Residentes.EditarResidente;
using Application.UseCase.Command.Residentes.EliminarResidente;
using Application.UseCase.Query.Residentes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/residente")]
    [ApiController]
    public class ResidenteController : ControllerBase
    {
        private readonly ILogger<ResidenteController> _logger;
        private readonly IMediator _mediator;

        public ResidenteController(IMediator mediator, ILogger<ResidenteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearResidente([FromBody] CrearResidenteCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el residente");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetListaResidentesQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("{nombre}")]
        [HttpGet]
        public async Task<IActionResult> GetResidente([FromRoute] string nombre)
        {
            var query = new GetResidenteByIdQuery()
            {
                Nombre = nombre
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarResidente([FromBody] EliminarResidenteCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el residente");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarResidente([FromBody] EditarResidenteCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al editar el residente");
                return BadRequest();
            }
        }
    }
}
