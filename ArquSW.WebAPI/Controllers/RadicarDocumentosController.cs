using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArquSW.WebAPI.DataContext;

namespace ArquSW.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadicarDocumentosController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RadicarDocumentosController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RadicarDocumentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RadicarDocumento>>> GetRadicarDocumento()
        {
            return await _context.RadicarDocumento
                .Include(doc => doc.Documento)
                .ToListAsync();
        }

        // GET: api/RadicarDocumentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RadicarDocumento>> GetRadicarDocumento(int id)
        {
            var radicarDocumento = await _context.RadicarDocumento
                .Include(doc => doc.Documento)
                .FirstOrDefaultAsync(doc => doc.Id == id);

            if (radicarDocumento == null)
            {
                return NotFound();
            }

            return radicarDocumento;
        }

        // PUT: api/RadicarDocumentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRadicarDocumento(int id, RadicarDocumento radicarDocumento)
        {
            if (id != radicarDocumento.Id)
            {
                return BadRequest();
            }

            _context.Entry(radicarDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadicarDocumentoExists(id))
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

        // POST: api/RadicarDocumentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RadicarDocumento>> PostRadicarDocumento(RadicarDocumento radicarDocumento)
        {
            _context.RadicarDocumento.Add(radicarDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRadicarDocumento", new { id = radicarDocumento.Id }, radicarDocumento);
        }

        // DELETE: api/RadicarDocumentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadicarDocumento(int id)
        {
            var radicarDocumento = await _context.RadicarDocumento
                .FindAsync(id);
            if (radicarDocumento == null)
            {
                return NotFound();
            }

            _context.RadicarDocumento.Remove(radicarDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RadicarDocumentoExists(int id)
        {
            return _context.RadicarDocumento.Any(e => e.Id == id);
        }
    }
}
