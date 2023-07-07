using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIForProject.Model;
using Microsoft.AspNetCore.Authorization;

namespace APIForProject.Controllers
{
    [Authorize(Roles ="Admin")]
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public AdministrationsController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administration>>> GetAdministrations()
        {
          if (_context.Administrations == null)
          {
              return NotFound();
          }
            return await _context.Administrations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Administration>> GetAdministration(int id)
        {
          if (_context.Administrations == null)
          {
              return NotFound();
          }
            var administration = await _context.Administrations.FindAsync(id);

            if (administration == null)
            {
                return NotFound();
            }

            return administration;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministration(int id, Administration administration)
        {
            if (id != administration.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(administration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrationExists(id))
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
        public async Task<ActionResult<Administration>> PostAdministration(Administration administration)
        {
          if (_context.Administrations == null)
          {
              return Problem("Entity set 'MainDbContext.Administrations'  is null.");
          }
               var r = await _context.Doctors.FindAsync(administration.DocID);
                _context.Administrations.Add(administration);
               if(r != null)
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetAdministration", new { id = administration.AdminId }, administration);

            }
            else
            {
                return BadRequest("Not an Id");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministration(int id)
        {
            if (_context.Administrations == null)
            {
                return NotFound();
            }
            var administration = await _context.Administrations.FindAsync(id);
            if (administration == null)
            {
                return NotFound();
            }

            _context.Administrations.Remove(administration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministrationExists(int id)
        {
            return (_context.Administrations?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
