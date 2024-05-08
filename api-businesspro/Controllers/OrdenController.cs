using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace api_businesspro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly ApiContext _context;

        public OrdenController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Orden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrearOrdenRequest>>> GetCrearOrdenRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.CrearOrdenRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Orden/5
        [HttpGet("{id}")]
        public ActionResult<CrearOrdenRequest> GetCrearOrdenRequest(long id)
        {
            if (!CrearOrdenRequestExists(id))
                return NotFound();

            return _context.CrearOrdenRequest
                    .Where(o => o.Id == id)
                    .Include(o => o.Detalles)
                    .Single();
        }

        // PUT: api/Orden/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrearOrdenRequest(long id, CrearOrdenRequest crearOrdenRequest)
        {
            if (id != crearOrdenRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (crearOrdenRequest.Detalles.Any(d => d.Id == 0))
                return BadRequest("One or more items in List<Detalles> has no valid id");

            _context.Update(crearOrdenRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearOrdenRequestExists(id))
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

        // POST: api/Orden
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrearOrdenRequest>> PostCrearOrdenRequest(CrearOrdenRequest crearOrdenRequest)
        {
            _context.CrearOrdenRequest.Add(crearOrdenRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearOrdenRequest), new { id = crearOrdenRequest.Id }, crearOrdenRequest);
        }

        // DELETE: api/Orden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrearOrdenRequest(long id)
        {
            var crearOrdenRequest = await _context.CrearOrdenRequest.FindAsync(id);
            if (crearOrdenRequest == null)
            {
                return NotFound();
            }

            _context.CrearOrdenRequest.Remove(crearOrdenRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearOrdenRequestExists(long id)
        {
            return _context.CrearOrdenRequest.Any(e => e.Id == id);
        }
    }
}
