using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace api_businesspro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesColorController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesColorController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesColor
        [HttpGet("{idUnidad}/{id}")]
        public ActionResult<UnidadColorRequest> GetUnidadColorRequest(long idUnidad, long id)
        {
            var colores = _context.UnidadColorRequest.Where(u => u.UnidadID == idUnidad);
            if (!colores.Any())
                return NotFound();

            var color = colores.ToList().Find(c => c.Id == id);
            if (color == null)
                return NotFound();

            return color;
        }

        // GET: api/UnidadesColor/5
        [HttpGet("{idUnidad}")]
        public ActionResult<List<UnidadColorRequest>> GetUnidadColorRequest(long idUnidad)
        {
            return _context.UnidadColorRequest.Where(c => c.UnidadID == idUnidad).ToList();
        }

        // PUT: api/UnidadesColor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idUnidad}/{id}")]
        public async Task<IActionResult> PutUnidadColorRequest(long idUnidad, long id, UnidadColorRequest unidadColorRequest)
        {
            if (id != unidadColorRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            var unidad = _context.CrearUnidadRequest.Find(idUnidad);
            if (unidad == null)
                return NotFound("There is no Unidades object with that id.");

            _context.Entry(unidadColorRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadColorRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UnidadesColor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idUnidad}")]
        public async Task<ActionResult<UnidadColorRequest>> PostUnidadColorRequest(long idUnidad, UnidadColorRequest unidadColorRequest)
        {
            var unidad = _context.CrearUnidadRequest.Find(idUnidad);
            if (unidad == null)
                return NotFound("There is no Unidades object with that id.");

            unidadColorRequest.UnidadID = unidad.Id;
            _context.UnidadColorRequest.Add(unidadColorRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostUnidadColorRequest), new { id = unidadColorRequest.Id }, unidadColorRequest);
        }

        // DELETE: api/UnidadesColor/5
        [HttpDelete("{idUnidad}/{id}")]
        public async Task<IActionResult> DeleteUnidadColorRequest(long idUnidad, long id)
        {
            var unidad = _context.CrearUnidadRequest.Find(idUnidad);
            if (unidad == null)
                return NotFound("There is no Unidades object with that id.");

            var unidadColorRequest = await _context.UnidadColorRequest.FindAsync(id);
            if (unidadColorRequest == null)
                return NotFound();

            _context.UnidadColorRequest.Remove(unidadColorRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadColorRequestExists(long id)
        {
            return _context.UnidadColorRequest.Any(e => e.Id == id);
        }
    }
}
