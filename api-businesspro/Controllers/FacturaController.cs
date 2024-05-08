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
    public class FacturaController : ControllerBase
    {
        private readonly ApiContext _context;

        public FacturaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaRequest>>> GetFacturaRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.FacturaRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaRequest>> GetFacturaRequest(long id)
        {
            var facturaRequest = await _context.FacturaRequest.FindAsync(id);
            if (facturaRequest == null)
                return NotFound();

            return facturaRequest;
        }

        // PUT: api/Factura/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaRequest(long id, FacturaRequest facturaRequest)
        {
            if (id != facturaRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            _context.Entry(facturaRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaRequestExists(id))
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

        // POST: api/Factura
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaRequest>> PostFacturaRequest(FacturaRequest facturaRequest)
        {
            _context.FacturaRequest.Add(facturaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostFacturaRequest), new { id = facturaRequest.Id }, facturaRequest);
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaRequest(long id)
        {
            var facturaRequest = await _context.FacturaRequest.FindAsync(id);
            if (facturaRequest == null)
            {
                return NotFound();
            }

            _context.FacturaRequest.Remove(facturaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaRequestExists(long id)
        {
            return _context.FacturaRequest.Any(e => e.Id == id);
        }
    }
}
