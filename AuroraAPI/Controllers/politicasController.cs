using AuroraAPI.Data;
using AuroraAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class politicasController : Controller
    {
        private readonly AuroraAPIContext _context;

        public politicasController(AuroraAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<politicas>>> GetPoliticas()
        {
            if (_context.politicas == null)
            {
                return NotFound();
            }
            return await _context.politicas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<politicas>> GetPoliticas(int id)
        {
            if (_context.politicas == null)
            {
                return NotFound();
            }
            var sobre = await _context.politicas.FindAsync(id);

            if (sobre == null)
            {
                return NotFound();
            }

            return sobre;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitcas(int id, politicas poli)
        {
            if (id != poli.idPolitica)
            {
                return BadRequest();
            }

            _context.Entry(poli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliticaExist(id))
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

        [HttpPost]
        public async Task<ActionResult<politicas>> PostPolitica(politicas poli)
        {
            if (_context.politicas == null)
            {
                return Problem("Entity set 'AuroraAPIContext.Politicas'  is null.");
            }
            _context.politicas.Add(poli);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoliticas", new { id = poli.idPolitica}, poli);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitica(int id)
        {
            if (_context.politicas == null)
            {
                return NotFound();
            }
            var sobre = await _context.politicas.FindAsync(id);
            if (sobre == null)
            {
                return NotFound();
            }

            _context.politicas.Remove(sobre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliticaExist(int id)
        {
            return (_context.politicas?.Any(e => e.idPolitica == id)).GetValueOrDefault();
        }
    }
}
