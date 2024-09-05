using Microsoft.AspNetCore.Mvc;
using sithecAPI.Data;
using sithecAPI.Models.Entities;
using sithecAPI.Models.Requests;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanosController : Controller
    {
        [HttpGet]
        public ActionResult<List<Humano>> GetHumanos()
        {
            List<Humano> humanos = HumanosData.GetHumanos();
            return Ok(humanos);
        }

        [HttpPost("operacion")]
        public ActionResult<double> Operacion([FromBody] OperacionRequest operaciones)
        {
            var operacion = GetOperaciones(operaciones);

            if (operacion.Result is BadRequestObjectResult)
            {
                return operacion.Result;
            }

            return Ok(new { Resultado = operacion.Value });
        }

        [HttpGet("operacion-header")]
        public IActionResult OperacionByHeader([FromHeader] OperacionRequest header)
        {
            var operacion = GetOperaciones(header);

            if (operacion.Result is BadRequestObjectResult)
            {
                return operacion.Result;
            }

            return Ok(new {resultado = operacion.Value});
        }

        public ActionResult<double> GetOperaciones(OperacionRequest operaciones)
        {
            if (operaciones == null)
            {
                return BadRequest("La solicitud no puede estar vacia");
            }

            double resultado = 0;

            switch (operaciones.Operacion.ToLower())
            {
                case "suma":
                    resultado = operaciones.Numero1 + operaciones.Numero2;
                    break;
                case "resta":
                    resultado = operaciones.Numero1 - operaciones.Numero2; ;
                    break;
                case "multiplicacion":
                    resultado = operaciones.Numero1 * operaciones.Numero2;
                    break;
                case "division":
                    if (operaciones.Numero2 == 0)
                    {
                        return BadRequest("No se puede dividir por 0");
                    }
                    else
                    {
                        resultado = operaciones.Numero1 / operaciones.Numero2;
                    }
                    break;
                default:
                    return BadRequest("Operacion no valida. Por favor usa (suma, resta, multiplicacion o division)");
            }

            return Ok(resultado);
        }

    }
}
