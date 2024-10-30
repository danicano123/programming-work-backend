using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.QualifiedRegistries.Models;

namespace programming_work_backend.Domain.QualifiedRegistries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualifiedRegistryController : ControllerBase
    {
        private readonly DBContext _context;

        public QualifiedRegistryController(DBContext context)
        {
            _context = context;
        }

        // GET: api/QualifiedRegistry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualifiedRegistry>>> GetQualifiedRegistries()
        {
            return await _context.QualifiedRegistries.ToListAsync();
        }

        // GET: api/QualifiedRegistry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QualifiedRegistry>> GetQualifiedRegistry(int id)
        {
            var qualifiedRegistry = await _context.QualifiedRegistries.FindAsync(id);

            if (qualifiedRegistry == null)
            {
                return NotFound();
            }

            return qualifiedRegistry;
        }

        // POST: api/QualifiedRegistry
        [HttpPost]
        public async Task<ActionResult<QualifiedRegistry>> CreateQualifiedRegistry(QualifiedRegistry qualifiedRegistry)
        {
            _context.QualifiedRegistries.Add(qualifiedRegistry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQualifiedRegistry), new { id = qualifiedRegistry.Id }, qualifiedRegistry);
        }

        // PUT: api/QualifiedRegistry/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQualifiedRegistry(int id, QualifiedRegistry qualifiedRegistry)
        {
            if (id != qualifiedRegistry.Id)
            {
                return BadRequest();
            }

            _context.Entry(qualifiedRegistry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualifiedRegistryExists(id))
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

        // DELETE: api/QualifiedRegistry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualifiedRegistry(int id)
        {
            var qualifiedRegistry = await _context.QualifiedRegistries.FindAsync(id);
            if (qualifiedRegistry == null)
            {
                return NotFound();
            }

            _context.QualifiedRegistries.Remove(qualifiedRegistry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/QualifiedRegistry/5/toggleIsActive
        [HttpPatch("{id}/toggleIsActive")]
        public async Task<IActionResult> ToggleIsActive(int id)
        {
            var qualifiedRegistry = await _context.QualifiedRegistries.FindAsync(id);
            if (qualifiedRegistry == null)
            {
                return NotFound();
            }

            qualifiedRegistry.IsActive = !qualifiedRegistry.IsActive;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualifiedRegistryExists(int id)
        {
            return _context.QualifiedRegistries.Any(e => e.Id == id);
        }
    }
}
