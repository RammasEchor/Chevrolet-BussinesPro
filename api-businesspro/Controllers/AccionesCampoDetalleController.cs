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
        [HttpGet("{idAccionesCampo}/{id}")]
        public ActionResult<AccionesCampoDetalleRequest> GetAccionesCampoDetalle(long idAccionesCampo, long id)
        {
            var accionesCampoDetalleRequest = _context.AccionesCampoDetalleRequest.Where(d => d.AccionCampoID == idAccionesCampo);
            if (!accionesCampoDetalleRequest.Any())
                return NotFound();

            var detalle = accionesCampoDetalleRequest.ToList().Find(d => d.Id == id);
            if (detalle == null)
                return NotFound();

            return detalle;
        }

        // GET: api/AccionesCampoDetalle/5
        [HttpGet("{idAccionesCampo}")]
        public ActionResult<List<AccionesCampoDetalleRequest>> GetAccionesCampoDetalleRequest(long idAccionesCampo)
        {
            var accionesCampoDetalleRequest = _context.AccionesCampoDetalleRequest.Where(d => d.AccionCampoID == idAccionesCampo);

            return accionesCampoDetalleRequest.ToList();
        }

        // PUT: api/AccionesCampoDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idAccionesCampo}/{id}")]
        public async Task<IActionResult> PutAccionesCampoDetalleRequest(long idAccionesCampo, long id, AccionesCampoDetalleRequest accionesCampoDetalleRequest)
        {
            if (id != accionesCampoDetalleRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            var accionCampo = _context.CrearAccionesCampoRequest.Find(idAccionesCampo);
            if (accionCampo == null)
                return NotFound("There is no AccionesCampo object with that id.");

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
        [HttpPost("{idAccionesCampo}")]
        public async Task<ActionResult<AccionesCampoDetalleRequest>> PostAccionesCampoDetalleRequest(long idAccionesCampo, AccionesCampoDetalleRequest accionesCampoDetalleRequest)
        {
            var accionCampo = _context.CrearAccionesCampoRequest.Find(idAccionesCampo);
            if (accionCampo == null)
                return NotFound("There is no AccionesCampo object with that id.");

            accionesCampoDetalleRequest.AccionCampoID = accionCampo.Id;
            _context.AccionesCampoDetalleRequest.Add(accionesCampoDetalleRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostAccionesCampoDetalleRequest), new { id = accionesCampoDetalleRequest.Id }, accionesCampoDetalleRequest);
        }

        // DELETE: api/AccionesCampoDetalle/5
        [HttpDelete("{idAccionesCampo}/{id}")]
        public async Task<IActionResult> DeleteAccionesCampoDetalleRequest(long idAccionesCampo, long id)
        {
            var accionCampo = _context.CrearAccionesCampoRequest.Find(idAccionesCampo);
            if (accionCampo == null)
                return NotFound("There is no AccionesCampo object with that id.");

            var accionesCampoDetalleRequest = await _context.AccionesCampoDetalleRequest.FindAsync(id);
            if (accionesCampoDetalleRequest == null)
                return NotFound();

            _context.AccionesCampoDetalleRequest.Remove(accionesCampoDetalleRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccionesCampoDetalleRequestExists(long id)
        {
            return _context.AccionesCampoDetalleRequest.Any(e => e.Id == id);
        }
    }
}
