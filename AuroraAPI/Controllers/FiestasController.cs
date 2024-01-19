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
    public class FiestasController : ControllerBase
    {
        private readonly AuroraAPIContext _context;

        public FiestasController(AuroraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Fiestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fiestas>>> GetFiestas()
        {
          if (_context.Fiestas == null)
          {
              return NotFound();
          }
            return await _context.Fiestas.ToListAsync();
        }

        // GET: api/Fiestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fiestas>> GetFiestas(int id)
        {
          if (_context.Fiestas == null)
          {
              return NotFound();
          }
            var fiestas = await _context.Fiestas.FindAsync(id);

            if (fiestas == null)
            {
                return NotFound();
            }

            return fiestas;
        }

        // PUT: api/Fiestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiestas(int id, Fiestas fiestas)
        {
            if (id != fiestas.idFiesta)
            {
                return BadRequest();
            }

            _context.Entry(fiestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiestasExists(id))
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
        public async Task<ActionResult<Fiestas>> PostFiestas(Fiestas fiestas)
        {
          if (_context.Fiestas == null)
          {
              return Problem("Entity set 'AuroraAPIContext.Fiestas'  is null.");
          }
            _context.Fiestas.Add(fiestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiestas", new { id = fiestas.idFiesta }, fiestas);
        }

        // DELETE: api/Fiestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiestas(int id)
        {
            if (_context.Fiestas == null)
            {
                return NotFound();
            }
            var fiestas = await _context.Fiestas.FindAsync(id);
            if (fiestas == null)
            {
                return NotFound();
            }

            _context.Fiestas.Remove(fiestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FiestasExists(int id)
        {
            return (_context.Fiestas?.Any(e => e.idFiesta == id)).GetValueOrDefault();
        }
    }
}
