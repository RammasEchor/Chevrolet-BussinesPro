using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.Data.Sqlite;

namespace api_businesspro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccionesCampoController : ControllerBase
    {
        private readonly ApiContext _context;

        public AccionesCampoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/AccionesCampo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearAccionesCampoRequest>>> GetAccionesCampo(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearAccionesCampoRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/AccionesCampo/5
        [HttpGet("{id}")]
        public ActionResult<CrearAccionesCampoRequest> GetCrearAccionesCampoRequest(long id)
        {
            if (!CrearAccionesCampoRequestExists(id))
                return NotFound();

            return _context.CrearAccionesCampoRequest
                    .Where(a => a.Id == id)
                    .Include(a => a.Detalles)
                    .Include(a => a.Series)
                    .Single();
        }

        // PUT: api/AccionesCampo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearAccionesCampoRequest(long id, CrearAccionesCampoRequest crearAccionesCampoRequest)
        {
            if (id != crearAccionesCampoRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (crearAccionesCampoRequest.Detalles.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Detalles> has no valid id");

            if (crearAccionesCampoRequest.Series.Any(o => o.Id == 0))
                return BadRequest("One or more items in List<Series> has no valid id");

            _context.Update(crearAccionesCampoRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearAccionesCampoRequestExists(id))
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

        // POST: api/AccionesCampo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearAccionesCampoRequest>> PostCrearAccionesCampoRequest(CrearAccionesCampoRequest crearAccionesCampoRequest)
        {
            _context.CrearAccionesCampoRequest.Add(crearAccionesCampoRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearAccionesCampoRequest), new { id = crearAccionesCampoRequest.Id }, crearAccionesCampoRequest);
        }

        // DELETE: api/AccionesCampo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearAccionesCampoRequest(long id)
        {
            var crearAccionesCampoRequest = await _context.CrearAccionesCampoRequest.FindAsync(id);
            if (crearAccionesCampoRequest == null)
                return NotFound();

            _context.CrearAccionesCampoRequest.Remove(crearAccionesCampoRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearAccionesCampoRequestExists(long id)
        {
            return _context.CrearAccionesCampoRequest.Any(e => e.Id == id);
        }
    }
}
