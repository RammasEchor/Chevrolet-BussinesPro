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
    public class PersonaController : ControllerBase
    {
        private readonly ApiContext _context;

        public PersonaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaRequest>>> GetPersonaRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.PersonaRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public ActionResult<PersonaRequest> GetPersonaRequest(long id)
        {
            if (!PersonaRequestExists(id))
                return NotFound();

            return _context.PersonaRequest.Where(p => p.Id == id)
                    .Include(p => p.Datospersonafisica)
                    .Include(p => p.Datospersonamoral)
                    .Include(p => p.Correos)
                    .Include(p => p.Direcciones)
                    .Include(p => p.Redessociales)
                    .Include(p => p.Relaciondms)
                    .Include(p => p.Telefonos)
                    .Include(p => p.Identificaciones)
                    .Single();

        }

        // PUT: api/Persona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaRequest(long id, PersonaRequest personaRequest)
        {
            if (id != personaRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            if (personaRequest.Datospersonafisica.Id == 0)
                return BadRequest("The item Datospersonafisica has no valid id");

            if (personaRequest.Datospersonamoral.Id == 0)
                return BadRequest("The item Datospersonamoral has no valid id");

            if (personaRequest.Correos.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Correos> has no valid id");

            if (personaRequest.Direcciones.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Direcciones> has no valid id");

            if (personaRequest.Redessociales.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Redessociales> has no valid id");

            if (personaRequest.Relaciondms.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Relaciondms> has no valid id");

            if (personaRequest.Telefonos.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Telefonos> has no valid id");

            if (personaRequest.Identificaciones.Any(p => p.Id == 0))
                return BadRequest("One or more items in List<Identificaciones> has no valid id");

            _context.Update(personaRequest);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaRequestExists(id))
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

        // POST: api/Persona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaRequest>> PostPersonaRequest(PersonaRequest personaRequest)
        {
            _context.PersonaRequest.Add(personaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostPersonaRequest), new { id = personaRequest.Id }, personaRequest);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaRequest(long id)
        {
            var personaRequest = await _context.PersonaRequest.FindAsync(id);
            if (personaRequest == null)
            {
                return NotFound();
            }

            _context.PersonaRequest.Remove(personaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaRequestExists(long id)
        {
            return _context.PersonaRequest.Any(e => e.Id == id);
        }
    }
}
