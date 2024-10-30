using Microsoft.AspNetCore.Mvc;
using programming_work_backend.Data;
using programming_work_backend.Domain.NormativeAspectProgramms.Models;
using Microsoft.EntityFrameworkCore;

namespace programming_work_backend.Domain.NormativeAspectProgramms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormativeAspectProgrammController : ControllerBase
    {
        private readonly DBContext _context;

        public NormativeAspectProgrammController(DBContext context)
        {
            _context = context;
        }

        // GET: api/NormativeAspectProgramm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormativeAspectProgramm>>> GetAll()
        {
            return await _context.NormativeAspectProgramms.ToListAsync();
        }

        // GET: api/NormativeAspectProgramm/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NormativeAspectProgramm>> GetById(int id)
        {
            var normativeAspectProgramm = await _context.NormativeAspectProgramms
                .FirstOrDefaultAsync(nap => nap.Id == id);

            if (normativeAspectProgramm == null)
                return NotFound();

            return normativeAspectProgramm;
        }

        // POST: api/NormativeAspectProgramm
        [HttpPost]
        public async Task<ActionResult<NormativeAspectProgramm>> Create(NormativeAspectProgramm normativeAspectProgramm)
        {
            _context.NormativeAspectProgramms.Add(normativeAspectProgramm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = normativeAspectProgramm.Id }, normativeAspectProgramm);
        }

        // PUT: api/NormativeAspectProgramm/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NormativeAspectProgramm normativeAspectProgramm)
        {
            if (id != normativeAspectProgramm.Id)
                return BadRequest();

            _context.Entry(normativeAspectProgramm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormativeAspectProgrammExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/NormativeAspectProgramm/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var normativeAspectProgramm = await _context.NormativeAspectProgramms.FindAsync(id);
            if (normativeAspectProgramm == null)
                return NotFound();

            _context.NormativeAspectProgramms.Remove(normativeAspectProgramm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NormativeAspectProgrammExists(int id)
        {
            return _context.NormativeAspectProgramms.Any(e => e.Id == id);
        }
    }
}
