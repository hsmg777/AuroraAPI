using AuroraAPI.Data;
using AuroraAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class contactController : Controller
    {
        private readonly AuroraAPIContext _context;

        public contactController(AuroraAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<contact>>> GetContact()
        {
            if (_context.contact == null)
            {
                return NotFound();
            }
            return await _context.contact.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<contact>> GetContact(int id)
        {
            if (_context.contact == null)
            {
                return NotFound();
            }
            var sobre = await _context.contact.FindAsync(id);

            if (sobre == null)
            {
                return NotFound();
            }

            return sobre;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, contact contact)
        {
            if (id != contact.idContact)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExist(id))
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
        public async Task<ActionResult<contact>> PostContact(contact contact)
        {
            if (_context.contact == null)
            {
                return Problem("Entity set 'AuroraAPIContext.contact'  is null.");
            }
            _context.contact.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.idContact }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (_context.contact == null)
            {
                return NotFound();
            }
            var sobre = await _context.contact.FindAsync(id);
            if (sobre == null)
            {
                return NotFound();
            }

            _context.contact.Remove(sobre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExist(int id)
        {
            return (_context.contact?.Any(e => e.idContact == id)).GetValueOrDefault();
        }
    }
}
