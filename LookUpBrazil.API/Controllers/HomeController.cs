using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LookUpBrazil.Api.Controllers
{
    [Route("Api")]
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
