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
    public class aboutController : ControllerBase
    {
        private readonly AuroraAPIContext _context;

        public aboutController(AuroraAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<about>>> GetAbout()
        {
            if (_context.aboutUs == null)
            {
                return NotFound();
            }
            return await _context.aboutUs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<about>> Getabout(int id)
        {
            if (_context.aboutUs == null)
            {
                return NotFound();
            }
            var sobre = await _context.aboutUs.FindAsync(id);

            if (sobre == null)
            {
                return NotFound();
            }

            return sobre;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putabout(int id, about about)
        {
            if (id != about.Id)
            {
                return BadRequest();
            }

            _context.Entry(about).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutExists(id))
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
        public async Task<ActionResult<about>> Postabout(about about)
        {
            if (_context.aboutUs == null)
            {
                return Problem("Entity set 'AuroraAPIContext.aboutUs'  is null.");
            }
            _context.aboutUs.Add(about);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getabout", new { id = about.Id }, about);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            if (_context.aboutUs == null)
            {
                return NotFound();
            }
            var sobre = await _context.aboutUs.FindAsync(id);
            if (sobre == null)
            {
                return NotFound();
            }

            _context.aboutUs.Remove(sobre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AboutExists(int id)
        {
            return (_context.aboutUs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
