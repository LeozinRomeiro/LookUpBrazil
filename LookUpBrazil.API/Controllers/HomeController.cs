using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LookUpBrazil.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
