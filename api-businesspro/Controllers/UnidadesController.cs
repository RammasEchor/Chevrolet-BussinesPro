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
    public class UnidadesController : ControllerBase
    {
        private readonly ApiContext _context;

        public UnidadesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Unidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearUnidadRequest>>> GetCrearUnidadRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearUnidadRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Unidades/5
        [HttpGet("{id}")]
        public ActionResult<CrearUnidadRequest> GetCrearUnidadRequest(long id)
        {
            if (!CrearUnidadRequestExists(id))
                return NotFound();


            return _context.CrearUnidadRequest.Where(v => v.Id == id)
                    .Include(v => v.Colores)
                    .Single();
        }

        // PUT: api/Unidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearUnidadRequest(long id, CrearUnidadRequest crearUnidadRequest)
        {
            if (id != crearUnidadRequest.Id)
                return BadRequest("The url id is not equal to the object id");


            if (crearUnidadRequest.Colores.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Colores> has no valid id");

            _context.Update(crearUnidadRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearUnidadRequestExists(id))
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

        // POST: api/Unidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearUnidadRequest>> PostCrearUnidadRequest(CrearUnidadRequest crearUnidadRequest)
        {
            _context.CrearUnidadRequest.Add(crearUnidadRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearUnidadRequest), new { id = crearUnidadRequest.Id }, crearUnidadRequest);
        }

        // DELETE: api/Unidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearUnidadRequest(long id)
        {
            var crearUnidadRequest = await _context.CrearUnidadRequest.FindAsync(id);
            if (crearUnidadRequest == null)
            {
                return NotFound();
            }

            _context.CrearUnidadRequest.Remove(crearUnidadRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearUnidadRequestExists(long id)
        {
            return _context.CrearUnidadRequest.Any(e => e.Id == id);
        }
    }
}
