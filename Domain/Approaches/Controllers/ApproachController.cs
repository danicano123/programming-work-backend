using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Approaches.Models;

namespace programming_work_backend.Domain.Approaches.Controllers;

[ApiController]
[Route("api/v1/approach")]
public class ApproachesController : ControllerBase
{
    private readonly DBContext _context;

    public ApproachesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetApproaches()
    {
        var approaches = await _context.Approaches.ToListAsync();
        return Ok(approaches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApproach(int id)
    {
        var approach = await _context.Approaches.FindAsync(id);
        if (approach == null)
        {
            return NotFound(new { message = "Approach not found." });
        }
        return Ok(approach);
    }

    [HttpPost]
    public async Task<IActionResult> CreateApproach([FromBody] Approach approach)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Approaches.Add(approach);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetApproach), new { id = approach.Id }, approach);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateApproach(int id, [FromBody] Approach approach)
    {
        if (id != approach.Id)
        {
            return BadRequest(new { message = "IB mismatch. "});
        }

        var existingApproach = await _context.Approaches.FindAsync(id);
        if (existingApproach == null)
        {
            return NotFound(new { message = "Approach not found." });
        }

        existingApproach.Description = approach.Description;
        existingApproach.Name = approach.Name;

        return NoContent();
    }

    [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteApproach(int id)
    {
        var approach = await _context.Approaches.FindAsync(id);
        if (approach == null)
        {
            return NotFound(new { message = "Focus not found." });
        }

        _context.Approaches.Remove(approach);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}