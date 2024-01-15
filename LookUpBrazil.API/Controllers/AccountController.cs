using LookUpBrazil.API.Data;
using LookUpBrazil.API.Extension;
using LookUpBrazil.API.Models;
using LookUpBrazil.API.Services;
using LookUpBrazil.API.ViewModels;
using LookUpBrazil.API.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Text.RegularExpressions;

namespace LookUpBrazil.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] RegisterViewModel model,
            [FromServices] LookUpBrazilAPIContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }
            var user = new User { Name = model.Name, Email = model.Email, };

            var password = PasswordGenerator.Generate(25);

            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(
                    new
                    {
                        user = user.Email, password = password
                    }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, new ResultViewModel<string>("05X99 - Email já cadastrado!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("APP02 - Falha interna!"));
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginViewModel model,
            [FromServices] LookUpBrazilAPIContext context,
            [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var user = await context.Users.AsNoTracking().Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
            {
                return StatusCode(401,new ResultViewModel<string>("Usuario ou senha invalida"));
            }

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
            {
                return StatusCode(401, new ResultViewModel<string>("Usuario ou senha invalida"));
            }

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, null));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("APP02 - Falha interna!"));
            }
        }

        [Authorize]
        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImageAsync(
            [FromBody] UploadImageViewModel model,
            [FromServices] LookUpBrazilAPIContext context)
        {
            var fileName = $"{Guid.NewGuid().ToString()}.jpg";
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, "");
            var bytes=Convert.FromBase64String(data);

            try
            {
                await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}",bytes);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("04343 - Falha interna"));
            }

            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            if(user == null) {
                return NotFound(new ResultViewModel<User>("Usuario não encontrado"));
            }

            user.Image = $"https://localhost:0000/images/{fileName}";

            try
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }

            return Ok(new ResultViewModel<string>("Imagem alterada com sucesso"));
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
