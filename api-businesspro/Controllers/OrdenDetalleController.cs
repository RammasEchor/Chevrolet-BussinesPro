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
    public class OrdenDetalleController : ControllerBase
    {
        private readonly ApiContext _context;

        public OrdenDetalleController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/OrdenDetalle
        [HttpGet("{idOrden}/{id}")]
        public ActionResult<CrearOrdenDetalleRequest> GetCrearOrdenDetalleRequest(long idOrden, long id)
        {
            var detalles = _context.CrearOrdenDetalleRequest.Where(o => o.OrdenID == idOrden);
            if (!detalles.Any())
                return NotFound();

            var detalle = detalles.ToList().Find(d => d.Id == id);
            if (detalle == null)
                return NotFound();

            return detalle;
        }

        // GET: api/OrdenDetalle/5
        [HttpGet("{idOrden}")]
        public ActionResult<List<CrearOrdenDetalleRequest>> GetCrearOrdenDetalleRequest(long idOrden)
        {
            var detalles = _context.CrearOrdenDetalleRequest.Where(o => o.OrdenID == idOrden);

            return detalles.ToList();
        }

        // PUT: api/OrdenDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idOrden}/{id}")]
        public async Task<IActionResult> PutCrearOrdenDetalleRequest(long idOrden, long id, CrearOrdenDetalleRequest crearOrdenDetalleRequest)
        {
            var orden = _context.CrearOrdenRequest.Find(idOrden);
            if (orden == null)
                return NotFound("There is no Orden object with that id.");

            if (id != crearOrdenDetalleRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            _context.Entry(crearOrdenDetalleRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrearOrdenDetalleRequestExists(id))
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

        // POST: api/OrdenDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idOrden}")]
        public async Task<ActionResult<CrearOrdenDetalleRequest>> PostCrearOrdenDetalleRequest(long idOrden, CrearOrdenDetalleRequest crearOrdenDetalleRequest)
        {
            var orden = _context.CrearOrdenRequest.Find(idOrden);
            if (orden == null)
                return NotFound("There is no Orden object with that id.");

            crearOrdenDetalleRequest.OrdenID = orden.Id;
            _context.CrearOrdenDetalleRequest.Add(crearOrdenDetalleRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCrearOrdenDetalleRequest), new { id = crearOrdenDetalleRequest.Id }, crearOrdenDetalleRequest);
        }

        // DELETE: api/OrdenDetalle/5
        [HttpDelete("{idOrden}/{id}")]
        public async Task<IActionResult> DeleteCrearOrdenDetalleRequest(long idOrden, long id)
        {
            var orden = _context.CrearOrdenRequest.Find(idOrden);
            if (orden == null)
                return NotFound("There is no Orden object with that id.");

            var crearOrdenDetalleRequest = await _context.CrearOrdenDetalleRequest.FindAsync(id);
            if (crearOrdenDetalleRequest == null)
                return NotFound();

            _context.CrearOrdenDetalleRequest.Remove(crearOrdenDetalleRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrearOrdenDetalleRequestExists(long id)
        {
            return _context.CrearOrdenDetalleRequest.Any(e => e.Id == id);
        }
    }
}
