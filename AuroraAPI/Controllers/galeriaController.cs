using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuroraAPI.Data;
using AuroraAPI.Models;


namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class galeriaController : ControllerBase
    {
        private readonly AuroraAPIContext _context;

        public galeriaController(AuroraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Fiestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<galeria>>>GetGaleria()
        {
          if (_context.Fiestas == null)
          {
              return NotFound();
          }
            return await _context.galeria.ToListAsync();
        }

        // GET: api/Fiestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<galeria>> GetGaleria(int id)
        {
          if (_context.galeria == null)
          {
              return NotFound();
          }
            var galeria = await _context.galeria.FindAsync(id);

            if (galeria == null)
            {
                return NotFound();
            }

            return galeria;
        }

        // PUT: api/Fiestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGaleria(int id, galeria galeria)
        {
            if (id != galeria.Id)
            {
                return BadRequest();
            }

            _context.Entry(galeria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaleriaExists(id))
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

        // POST: api/Fiestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<galeria>> PostGaleria(galeria galeria)
        {
          if (_context.galeria == null)
          {
              return Problem("Entity set 'AuroraAPIContext.galeria'  is null.");
          }
            _context.galeria.Add(galeria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGaleria", new { id = galeria.Id }, galeria);
        }

        // DELETE: api/Fiestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGaleria(int id)
        {
            if (_context.galeria == null)
            {
                return NotFound();
            }
            var galeria = await _context.galeria.FindAsync(id);
            if (galeria == null)
            {
                return NotFound();
            }

            _context.galeria.Remove(galeria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GaleriaExists(int id)
        {
            return (_context.galeria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
