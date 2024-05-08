using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace api_businesspro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly ApiContext _context;

        public PaquetesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearPaqueteRequest>>> GetCrearPaqueteRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearPaqueteRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Paquetes/5
        [HttpGet("{id}")]
        public ActionResult<CrearPaqueteRequest> GetCrearPaqueteRequest(long id)
        {
            if (!CrearPaqueteRequestExists(id))
                return NotFound();

            return _context.CrearPaqueteRequest
                    .Where(p => p.Id == id)
                    .Include(p => p.Partes)
                    .Include(p => p.Operaciones)
                    .Include(p => p.Tots)
                    .Include(p => p.Vehiculos)
                    .Single();
        }

        // PUT: api/Paquetes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearPaqueteRequest(long id, CrearPaqueteRequest crearPaqueteRequest)
        {
            if (id != crearPaqueteRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (crearPaqueteRequest.Partes.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Partes> has no valid id");

            if (crearPaqueteRequest.Operaciones.Any(o => o.Id == 0))
                return BadRequest("One or more items in List<Operaciones> has no valid id");

            if (crearPaqueteRequest.Tots.Any(t => t.Id == 0))
                return BadRequest("One or more items in List<Tots> has no valid id");

            if (crearPaqueteRequest.Vehiculos.Any(v => v.Id == 0))
                return BadRequest("One or more items in List<Vehiculos> has no valid id");

            _context.Update(crearPaqueteRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearPaqueteRequestExists(id))
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

        // POST: api/Paquetes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearPaqueteRequest>> PostCrearPaqueteRequest(CrearPaqueteRequest crearPaqueteRequest)
        {
            _context.CrearPaqueteRequest.Add(crearPaqueteRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearPaqueteRequest), new { id = crearPaqueteRequest.Id }, crearPaqueteRequest);
        }

        // DELETE: api/Paquetes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearPaqueteRequest(long id)
        {
            var crearPaqueteRequest = await _context.CrearPaqueteRequest.FindAsync(id);
            if (crearPaqueteRequest == null)
            {
                return NotFound();
            }

            _context.CrearPaqueteRequest.Remove(crearPaqueteRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearPaqueteRequestExists(long id)
        {
            return _context.CrearPaqueteRequest.Any(e => e.Id == id);
        }
    }
}
