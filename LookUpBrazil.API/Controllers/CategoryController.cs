using LookUpBrazil.Api.Data;
using LookUpBrazil.Api.Extension;
using LookUpBrazil.Api.ViewModels.Locations;
using LookUpBrazil.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.Api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace LookUpBrazil.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: Api/Category
        [HttpGet]
        public async Task<ActionResult> GetAsync(
            [FromServices] IMemoryCache memoryCache,    
            [FromServices] LookUpBrazilApiContext context,
            [FromQuery] int page = 0, [FromQuery] int pageSize = 20)
        {
            try
            {
                //var categories = memoryCache.GetOrCreate("CategoriesCache", entry =>
                //{
                //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                //    return GetAsync(context);
                //});
                var categories = await context.Categories.AsNoTracking().Select(x => new {
                   x.Name
                }).Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

                //return Ok(new ResultViewModel<dynamic>(new
                //{
                //    page,
                //    pageSize,
                //    categories
                //}));

                return Ok(categories);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Location>>("APG02 - Falha interna!"));
            }
        }

        // GET: Api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(
            [FromRoute] Guid id,
            [FromServices] LookUpBrazilApiContext context)
        {
            try
            {
                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<string>("APG02 - Falha interna!"));
            }
        }

        // POST: Api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(
            [FromBody] EditorCategoryViewModel model,
            [FromServices] LookUpBrazilApiContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            try
            {
                var category = new Category
                {
                    Name = model.Name,
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"Api/Category/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Location>("APP01 - Não foi possivel incluir registro!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Location>("APP02 - Falha interna!"));
            }
        }

        // PUT: Api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(
            Guid id,
            [FromBody] EditorCategoryViewModel model,
            [FromServices] LookUpBrazilApiContext context)

        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));

                //_context.Entry(location).State = EntityState.Modified;
                category.Name = model.Name;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<string>("APP01 - Não foi possivel incluir registro!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("APP02 - Falha interna!"));
            }
        }

        // DELETE: Api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(
            Guid id,
            [FromServices] LookUpBrazilApiContext context)
        {

            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<string>("APP01 - Não foi possivel incluir registro!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("APP02 - Falha interna!"));
            }

        }

    }
}
