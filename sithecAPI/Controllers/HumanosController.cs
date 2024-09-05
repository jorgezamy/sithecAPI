using Microsoft.AspNetCore.Mvc;
using sithecAPI.Data;
using sithecAPI.Models.Entities;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Humano>> GetHumanos()
        {
            List<Humano> humanos = HumanosData.GetHumanos();
            return Ok(humanos);
        }
    }
}
