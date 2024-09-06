using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sithecAPI.Data;
using sithecAPI.Models.Entities;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/humanos")]
    public class HumanosController : ControllerBase
    {
        private readonly ApiContext _context;

        public HumanosController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("mock")]
        public ActionResult<List<Humano>> GetHumanosMock()
        {
            List<Humano> humanos = HumanosData.GetHumanos();
            return Ok(humanos);
        }

        [HttpGet]
        public async Task<ActionResult<Humano>> GetHumanos()
        {
            var humanos = await _context.Humanos.ToListAsync();

            return Ok(humanos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumanoById(int id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return Ok(humano);
        }

        [HttpPost]
        public async Task<ActionResult<Humano>> CreateHumano([FromBody] Humano humano)
        {
            var newHumano = await _context.Humanos.FirstOrDefaultAsync(u => u.Nombre == humano.Nombre && u.Edad == humano.Edad && u.Altura == humano.Altura);

            if (newHumano != null)
            {
                return Conflict("Ya existe el humano registrado en la BD.");
            }

            _context.Humanos.Add(humano);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error interno del sistema {ex.Message}");
            }

            return CreatedAtAction(nameof(CreateHumano), new {id= humano.Id}, humano);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHumano(string id, [FromBody] Humano humano)
        {
            if (id != humano.Id.ToString())
            {
                return BadRequest(new {status="Error"});
            }

            var humanosUpdated = await _context.Humanos.FindAsync(id);

            if (humanosUpdated == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHumano(Guid id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                return NotFound();
            }

            _context.Humanos.Remove(humano);

            await _context.SaveChangesAsync();

            return Ok(new { status = "Ok", message = "Humano eliminado exitosamente" });
        }
    }
}
