using Microsoft.AspNetCore.Mvc;
using sithecAPI.Models.Requests;
using sithecAPI.utilities;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesController : ControllerBase
    {
        [HttpPost("operacion")]
        public IActionResult Operacion([FromBody] OperacionRequest operaciones)
        {
            return OperacionesResult(operaciones);
        }

        [HttpGet("operacion-header")]
        public IActionResult OperacionByHeader([FromHeader(Name = "Numero1")] double numero1, [FromHeader(Name = "Numero2")] double numero2, [FromHeader(Name = "Operacion")] string operacion)
        {
            var operacionHeader = new OperacionRequest { Numero1 = numero1, Numero2 = numero2, Operacion = operacion };

            return OperacionesResult(operacionHeader);
        }

        private IActionResult OperacionesResult(OperacionRequest operaciones)
        {
            if (operaciones == null)
            {
                return BadRequest("La solicitud no puede estar vacía.");
            }

            try
            {
                var operacion = OperationsUtilities.GetOperaciones(operaciones);
                return Ok(new { Resultado = operacion });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
