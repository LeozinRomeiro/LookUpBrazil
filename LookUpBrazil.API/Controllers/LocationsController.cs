using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.API.Data;
using LookUpBrazil.API.Models;
using LookUpBrazil.API.ViewModels;
using LookUpBrazil.API.Extension;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LookUpBrazil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly LookUpBrazilAPIContext _context;

        public LocationsController(LookUpBrazilAPIContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult> GetLocation()
        {
            try
            {
                var locations = await _context.Location.ToListAsync();

                return Ok(new ResultViewModel<List<Location>>(locations));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Location>>("APG02 - Falha interna!"));
            }
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(Guid id)
        {
            try
            {
                var location = await _context.Location.FirstOrDefaultAsync(x=>x.Id==id);

                if (location == null)
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));

                return Ok(new ResultViewModel<Location>(location));
            }
            catch (Exception)
            {

                return StatusCode(500, new ResultViewModel<Location>("APG02 - Falha interna!"));
            }
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(Guid id, Location model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Location>(ModelState.GetErrors()));

            try
            {
                var location = await _context.Location.FirstOrDefaultAsync(x=>x.Id == id);
                if (location == null)
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));

                //_context.Entry(location).State = EntityState.Modified;
                location.State = model.State;
                location.City = model.City;
                
                _context.Location.Update(location);
                await _context.SaveChangesAsync();

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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Location>(ModelState.GetErrors()));
            try
            {
                var location = new Location
                {
                    State = model.State,
                    City = model.City,
                };
                await _context.Location.AddAsync(location);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocation", new ResultViewModel<Location>(location));
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

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            try
            {
                var location = await _context.Location.FirstOrDefaultAsync(x => x.Id == id);
                if (location == null)
                {
                    return NotFound(new ResultViewModel<Location>("Conteudo não encontrado"));
                }

                _context.Location.Remove(location);
                await _context.SaveChangesAsync();

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
