using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sithecAPI.Data;
using sithecAPI.Models.Entities;
using sithecAPI.Services.interfaces;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/humanos")]
    public class HumanosController : ControllerBase
    {
        private readonly IHumanosService _humanosService;

        public HumanosController(IHumanosService humanosService)
        {
            _humanosService = humanosService;
        }

        [HttpGet("mock")]
        public ActionResult<List<Humano>> GetHumanosMock()
        {
            var humanos = _humanosService.GetHumanosMock();
            return Ok(humanos);
        }

        [HttpGet]
        public async Task<ActionResult<Humano>> GetHumanos()
        {
            var humanos = await _humanosService.GetHumanosAsync();

            return Ok(humanos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumanoById(Guid id)
        {
            try
            {
                var humano = await _humanosService.GetHumanoByIdAsync(id);
                return Ok(humano);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Humano>> CreateHumano([FromBody] Humano humano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "Error", Message = ModelState });
            }

            var newHumano = await _humanosService.CreateHumanoAsync(humano);

            return CreatedAtAction(nameof(CreateHumano), new { id = newHumano.Id }, new { status = "Ok", result = humano });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHumanoById(Guid id, [FromBody] Humano humano)
        {
            if (id != humano.Id)
            {
                return BadRequest(new { status = "Error", result = "Humano ID no coincide." });
            }

            var humanoUpdated = await _humanosService.UpdateHumanoByIdAsync(id, humano);

            if (!humanoUpdated)
            {
                return NotFound();
            }

            return Ok(new { status = "Ok", result = humanoUpdated });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHumanoById(Guid id)
        {
            var humano = await _humanosService.DeleteHumanoByIdAsync(id);

            if (!humano)
            {
                return NotFound();
            }

            return Ok(new { status = "Ok", result = "Humano eliminado exitosamente" });
        }
    }
}
