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
    public class VehiculoController : ControllerBase
    {
        private readonly ApiContext _context;

        public VehiculoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearVehiculoRequest>>> GetCrearVehiculoRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearVehiculoRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();

        }

        // GET: api/Vehiculo/5
        [HttpGet("{id}")]
        public ActionResult<CrearVehiculoRequest> GetCrearVehiculoRequest(long id)
        {
            if (!CrearVehiculoRequestExists(id))
                return NotFound();

            return _context.CrearVehiculoRequest.Where(v => v.Id == id)
                    .Include(v => v.Otrasmarcas)
                    .Single();
        }

        // PUT: api/Vehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearVehiculoRequest(long id, CrearVehiculoRequest crearVehiculoRequest)
        {
            if (id != crearVehiculoRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (crearVehiculoRequest.Otrasmarcas.Id == 0)
                return BadRequest("The item Otrasmarcas has no valid id");

            _context.Update(crearVehiculoRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearVehiculoRequestExists(id))
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

        // POST: api/Vehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearVehiculoRequest>> PostCrearVehiculoRequest(CrearVehiculoRequest crearVehiculoRequest)
        {
            _context.CrearVehiculoRequest.Add(crearVehiculoRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearVehiculoRequest), new { id = crearVehiculoRequest.Id }, crearVehiculoRequest);
        }

        // DELETE: api/Vehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearVehiculoRequest(long id)
        {
            var crearVehiculoRequest = await _context.CrearVehiculoRequest.FindAsync(id);
            if (crearVehiculoRequest == null)
            {
                return NotFound();
            }

            _context.CrearVehiculoRequest.Remove(crearVehiculoRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearVehiculoRequestExists(long id)
        {
            return _context.CrearVehiculoRequest.Any(e => e.Id == id);
        }
    }
}
