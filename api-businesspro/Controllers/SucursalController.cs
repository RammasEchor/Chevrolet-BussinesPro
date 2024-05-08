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
    public class SucursalController : ControllerBase
    {
        private readonly ApiContext _context;

        public SucursalController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sucursal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalRequest>>> GetSucursalRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.SucursalRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Sucursal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalRequest>> GetSucursalRequest(long id)
        {
            var sucursalRequest = await _context.SucursalRequest.FindAsync(id);

            if (sucursalRequest == null)
            {
                return NotFound();
            }

            return sucursalRequest;
        }

        // PUT: api/Sucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursalRequest(long id, SucursalRequest sucursalRequest)
        {
            if (id != sucursalRequest.Id)
                return BadRequest("The url id is not equal to the object id");


            _context.Entry(sucursalRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalRequestExists(id))
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

        // POST: api/Sucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SucursalRequest>> PostSucursalRequest(SucursalRequest sucursalRequest)
        {
            _context.SucursalRequest.Add(sucursalRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSucursalRequest), new { id = sucursalRequest.Id }, sucursalRequest);
        }

        // DELETE: api/Sucursal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursalRequest(long id)
        {
            var sucursalRequest = await _context.SucursalRequest.FindAsync(id);
            if (sucursalRequest == null)
            {
                return NotFound();
            }

            _context.SucursalRequest.Remove(sucursalRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalRequestExists(long id)
        {
            return _context.SucursalRequest.Any(e => e.Id == id);
        }
    }
}
