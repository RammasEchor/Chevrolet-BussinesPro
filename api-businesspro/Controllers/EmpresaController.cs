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
    public class EmpresaController : ControllerBase
    {
        private readonly ApiContext _context;

        public EmpresaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaRequest>>> GetEmpresaRequest(
            [FromQuery] int page,
            [FromQuery] int size
        )
        {
            var list = await _context.EmpresaRequest.ToListAsync();
            return list.Skip(page * size).Take(size).ToList();

        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaRequest>> GetEmpresaRequest(long id)
        {
            var empresaRequest = await _context.EmpresaRequest.FindAsync(id);
            if (empresaRequest == null)
                return NotFound();

            return empresaRequest;
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaRequest(long id, EmpresaRequest empresaRequest)
        {
            if (id != empresaRequest.Id)
                return BadRequest("The url id is not equal to the object id");

            _context.Entry(empresaRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaRequestExists(id))
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

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpresaRequest>> PostEmpresaRequest(EmpresaRequest empresaRequest)
        {
            _context.EmpresaRequest.Add(empresaRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostEmpresaRequest), new { id = empresaRequest.Id }, empresaRequest);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaRequest(long id)
        {
            var empresaRequest = await _context.EmpresaRequest.FindAsync(id);
            if (empresaRequest == null)
                return NotFound();

            _context.EmpresaRequest.Remove(empresaRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaRequestExists(long id)
        {
            return _context.EmpresaRequest.Any(e => e.Id == id);
        }
    }
}
