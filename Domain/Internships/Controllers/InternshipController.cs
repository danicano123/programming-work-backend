using Microsoft.AspNetCore.Mvc;
using programming_work_backend.Data;
using programming_work_backend.Domain.Internships.Models;
using Microsoft.EntityFrameworkCore;

namespace programming_work_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipController : ControllerBase
    {
        private readonly DBContext _context;

        public InternshipController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Internship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Internship>>> GetAll()
        {
            return await _context.Internships.Include(i => i.Programm).ToListAsync();
        }

        // GET: api/Internship/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Internship>> GetById(int id)
        {
            var internship = await _context.Internships
                .Include(i => i.Programm)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (internship == null)
                return NotFound();

            return internship;
        }

        // POST: api/Internship
        [HttpPost]
        public async Task<ActionResult<Internship>> Create(Internship internship)
        {
            _context.Internships.Add(internship);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = internship.Id }, internship);
        }

        // PUT: api/Internship/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Internship internship)
        {
            if (id != internship.Id)
                return BadRequest();

            _context.Entry(internship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternshipExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Internship/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship == null)
                return NotFound();

            _context.Internships.Remove(internship);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternshipExists(int id)
        {
            return _context.Internships.Any(i => i.Id == id);
        }
    }
}
