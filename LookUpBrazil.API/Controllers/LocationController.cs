using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.Api.Data;
using LookUpBrazil.Api.Models;
using LookUpBrazil.Api.ViewModels;
using LookUpBrazil.Api.Extension;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LookUpBrazil.Api.ViewModels.Locations;

namespace LookUpBrazil.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // GET: Api/Location
        [HttpGet]
        public async Task<ActionResult> GetAsync(
            [FromServices] LookUpBrazilApiContext context,
            [FromQuery] int page = 0, [FromQuery] int pageSize = 20)
        {
            try
            {
                var locations = await context.Locations.AsNoTracking().Include(x => x.Category).Select(x => new ListLocationsViewModel {
                    State = x.State,
                    City = x.City,
                    Category = x.Category.Name,
                    LastUpdateDate = x.LastUpdateDate,
                }).Skip(page * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    page,
                    pageSize,
                    locations
                }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Location>>("APG02 - Falha interna!"));
            }
        }

        // GET: Api/Location/Category
        [HttpGet("Category/{category}")]
        public async Task<ActionResult> GetByCategoryAsync(
            [FromRoute] string category,
            [FromServices] LookUpBrazilApiContext context,
            [FromQuery] int page = 0, [FromQuery] int pageSize = 20)
        {
            try
            {
                var locations = await context.Locations.AsNoTracking().Include(x => x.Category).Where(x=>x.Category.Name==category).Select(x => new ListLocationsViewModel
                {
                    State = x.State,
                    City = x.City,
                    Category = x.Category.Name,
                    LastUpdateDate = x.LastUpdateDate,
                }).Skip(page * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    page,
                    pageSize,
                    locations
                }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Location>>("APG02 - Falha interna!"));
            }
        }

        // GET: Api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLocation(
            [FromRoute] Guid id,
            [FromServices] LookUpBrazilApiContext context)
        {
            try
            {
                var location = await context.Locations.AsNoTracking().Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

                if (location == null)
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));

                return Ok(new ResultViewModel<Location>(location));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Location>("APG02 - Falha interna!"));
            }
        }

        // PUT: Api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(
            Guid id,
            [FromBody] EditorLocationViewModel model,
            [FromServices] LookUpBrazilApiContext context)
            
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Location>(ModelState.GetErrors()));

            try
            {
                var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                if (location == null)
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));

                var modelCategory = context.Categories.Find(model.CategoryId);

                if (modelCategory == null)
                {
                    return StatusCode(500, new ResultViewModel<Location>("APP03 - Categoria invalida"));
                }

                //_context.Entry(location).State = EntityState.Modified;
                location.State = model.State;
                location.City = model.City;
                location.Category = modelCategory;
                location.LastUpdateDate = model.LastUpdateDate;

                context.Locations.Update(location);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Location>(location));
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

        // POST: Api/Locations
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(
            [FromBody] EditorLocationViewModel model,
            [FromServices] LookUpBrazilApiContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Location>(ModelState.GetErrors()));
            try
            {
                var modelCategory = context.Categories.Find(model.CategoryId);

                if (modelCategory == null)
                {
                    return StatusCode(500, new ResultViewModel<Location>("APP03 - Categoria invalida"));
                }

                var location = new Location
                {
                    State = model.State,
                    City = model.City,
                    LastUpdateDate = model.LastUpdateDate,
                    Category = modelCategory
                };
                await context.Locations.AddAsync(location);
                await context.SaveChangesAsync();

                return Created($"Api/Location/{location.Id}", new ResultViewModel<Location>(location));
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

        // DELETE: Api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(
            [FromBody] Guid id,
            [FromServices] LookUpBrazilApiContext context)
        {
            try
            {
                var location = await context.Locations.FirstOrDefaultAsync(x => x.Id == id);
                if (location == null)
                {
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));
                }

                context.Locations.Remove(location);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Location>(location));
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

        //private bool LocationExists(Guid id)
        //{
        //    return _context.Location.Any(e => e.Id == id);
        //}
    }
}
