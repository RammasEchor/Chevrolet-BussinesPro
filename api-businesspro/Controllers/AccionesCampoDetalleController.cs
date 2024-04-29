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
    public class AccionesCampoDetalleController : ControllerBase
    {
        private readonly ApiContext _context;

        public AccionesCampoDetalleController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/AccionesCampoDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccionesCampoDetalleRequest>>> GetAccionesCampoDetalle()
        {
            return await _context.AccionesCampoDetalle.ToListAsync();
        }

        // GET: api/AccionesCampoDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccionesCampoDetalleRequest>> GetAccionesCampoDetalleRequest(long id)
        {
            var accionesCampoDetalleRequest = await _context.AccionesCampoDetalle.FindAsync(id);

            if (accionesCampoDetalleRequest == null)
            {
                return NotFound();
            }

            return accionesCampoDetalleRequest;
        }

        // PUT: api/AccionesCampoDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccionesCampoDetalleRequest(long id, AccionesCampoDetalleRequest accionesCampoDetalleRequest)
        {
            if (id != accionesCampoDetalleRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(accionesCampoDetalleRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccionesCampoDetalleRequestExists(id))
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

        // POST: api/AccionesCampoDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccionesCampoDetalleRequest>> PostAccionesCampoDetalleRequest(AccionesCampoDetalleRequest accionesCampoDetalleRequest)
        {
            _context.AccionesCampoDetalle.Add(accionesCampoDetalleRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostAccionesCampoDetalleRequest), new { id = accionesCampoDetalleRequest.Id }, accionesCampoDetalleRequest);
        }

        // DELETE: api/AccionesCampoDetalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccionesCampoDetalleRequest(long id)
        {
            var accionesCampoDetalleRequest = await _context.AccionesCampoDetalle.FindAsync(id);
            if (accionesCampoDetalleRequest == null)
            {
                return NotFound();
            }

            _context.AccionesCampoDetalle.Remove(accionesCampoDetalleRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccionesCampoDetalleRequestExists(long id)
        {
            return _context.AccionesCampoDetalle.Any(e => e.Id == id);
        }
    }
}
