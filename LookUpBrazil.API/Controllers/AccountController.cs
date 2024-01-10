using LookUpBrazil.API.Data;
using LookUpBrazil.API.Extension;
using LookUpBrazil.API.Models;
using LookUpBrazil.API.Services;
using LookUpBrazil.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LookUpBrazil.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> Post(
            [FromBody] RegisterViewModel model,
            [FromServices] LookUpBrazilAPIContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }
            var user = new User { Name = model.Name, Email = model.Email, };
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromServices] TokenService tokenService)
        {
            var token = tokenService.GenerateToken(null);

            return Ok(token);
        }

        [Authorize(Roles ="user")]
        [HttpGet("user")]
        public IActionResult GetUser() => Ok(User.Identity.Name);


        [Authorize(Roles = "admin")]
        [HttpGet("admin")]
        public IActionResult GetAdmin() => Ok(User.Identity.Name);


        [Authorize(Roles = "author")]
        [HttpGet("author")]
        public IActionResult GetAuthor() => Ok(User.Identity.Name);
    }
}
