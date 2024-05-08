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
    public class CitaController : ControllerBase
    {
        private readonly ApiContext _context;

        public CitaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearCitaRequest>>> GetCrearCitaRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearCitaRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public ActionResult<CrearCitaRequest> GetCrearCitaRequest(long id)
        {
            if (!CrearCitaRequestExists(id))
                return NotFound();

            var crearCitaRequest = _context.CrearCitaRequest.Where(c => c.Id == id)
                                                                .Include(c => c.Paquetes)
                                                                .Include(c => c.AccionesCampo)
                                                                .Single();

            if (crearCitaRequest == null)
            {
                return NotFound();
            }

            return crearCitaRequest;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearCitaRequest(long id, CrearCitaRequest crearCitaRequest)
        {
            if (id != crearCitaRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (crearCitaRequest.Paquetes.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Paquetes> has no valid id");

            if (crearCitaRequest.AccionesCampo.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<AccionesCampo> has no valid id");

            _context.Update(crearCitaRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearCitaRequestExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearCitaRequest>> PostCrearCitaRequest(CrearCitaRequest crearCitaRequest)
        {
            _context.CrearCitaRequest.Add(crearCitaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearCitaRequest), new { id = crearCitaRequest.Id }, crearCitaRequest);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearCitaRequest(long id)
        {
            var crearCitaRequest = await _context.CrearCitaRequest.FindAsync(id);
            if (crearCitaRequest == null)
            {
                return NotFound();
            }

            _context.CrearCitaRequest.Remove(crearCitaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearCitaRequestExists(long id)
        {
            return _context.CrearCitaRequest.Any(e => e.Id == id);
        }
    }
}
