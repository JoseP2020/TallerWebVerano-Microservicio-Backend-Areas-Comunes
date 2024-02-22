using Application.UseCase.Command.Condominios.EditarCondominio;
using Application.UseCase.Command.Reservas.AceptarReserva;
using Application.UseCase.Command.Reservas.CrearReserva;
using Application.UseCase.Command.Reservas.EditarReserva;
using Application.UseCase.Command.Reservas.EliminarReserva;
using Application.UseCase.Command.Reservas.MandarAEspera;
using Application.UseCase.Query.Reservas;
using Application.UseCase.Query.Residentes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{

    [Route("api/reserva")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ILogger<ReservaController> _logger;
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator, ILogger<ReservaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva([FromBody] CrearReservaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el reserva");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetListaReservasQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("{residenteId}")]
        [HttpGet]
        public async Task<IActionResult> GetReserva([FromRoute] Guid residenteId)
        {
            var query = new GetReservasByIdQuery()
            {
                ResidenteId = residenteId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarReserva([FromBody] EliminarReservaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el reserva");
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarReserva([FromBody] EditarReservaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al editar la reserva");
                return BadRequest();
            }
        }

        [Route("aceptar")]
        [HttpPut]
        public async Task<IActionResult> AceptarReserva([FromBody] AceptarReservaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al aceptar la reserva");
                return BadRequest();
            }
        }

        [Route("espera")]
        [HttpPut]
        public async Task<IActionResult> MandarAEsperaReserva([FromBody] MandarAEsperaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al mandar la reserva a espera");
                return BadRequest();
            }
        }
    }
}
