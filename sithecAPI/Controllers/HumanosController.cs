using Microsoft.AspNetCore.Mvc;
using sithecAPI.Data;
using sithecAPI.Models;

namespace sithecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanosController : Controller
    {
        [HttpGet]
        public ActionResult<List<Humano>> getHumanos()
        {
            List<Humano> humanos = HumanosData.GetHumanos();
            return Ok(humanos);
        }
    }
}
