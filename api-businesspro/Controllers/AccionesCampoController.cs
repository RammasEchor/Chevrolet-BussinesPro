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
    public class AccionesCampoController : ControllerBase
    {
        private readonly ApiContext _context;

        public AccionesCampoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/AccionesCampo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearAccionesCampoRequest>>> GetAccionesCampo()
        {
            return await _context.AccionesCampo.ToListAsync();
        }

        // GET: api/AccionesCampo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CrearAccionesCampoRequest>> GetCrearAccionesCampoRequest(long id)
        {
            var crearAccionesCampoRequest = await _context.AccionesCampo.FindAsync(id);

            if (crearAccionesCampoRequest == null)
            {
                return NotFound();
            }

            return crearAccionesCampoRequest;
        }

        // PUT: api/AccionesCampo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearAccionesCampoRequest(long id, CrearAccionesCampoRequest crearAccionesCampoRequest)
        {
            if (id != crearAccionesCampoRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(crearAccionesCampoRequest).State = EntityState.Modified;

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
            _context.AccionesCampo.Add(crearAccionesCampoRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearAccionesCampoRequest), new { id = crearAccionesCampoRequest.Id }, crearAccionesCampoRequest);
        }

        // DELETE: api/AccionesCampo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearAccionesCampoRequest(long id)
        {
            var crearAccionesCampoRequest = await _context.AccionesCampo.FindAsync(id);
            if (crearAccionesCampoRequest == null)
            {
                return NotFound();
            }

            _context.AccionesCampo.Remove(crearAccionesCampoRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearAccionesCampoRequestExists(long id)
        {
            return _context.AccionesCampo.Any(e => e.Id == id);
        }
    }
}
