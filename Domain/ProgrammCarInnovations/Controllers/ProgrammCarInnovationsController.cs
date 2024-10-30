using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.ProgrammCarInnovations.Models;

namespace programming_work_backend.Domain.ProgrammCarInnovations.Controllers;

[ApiController]
[Route("api/v1/programm-car-innovations")]
public class ProgrammCarInnovationsController : ControllerBase
{
    private readonly DBContext _context;

    public ProgrammCarInnovationsController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProgrammCarInnovations()
    {
        var programmCarInnovations = await _context.ProgrammCarInnovations.ToListAsync();
        return Ok(programmCarInnovations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgrammCarInnovation(int id)
    {
        var programmCarInnovation = await _context.ProgrammCarInnovations.FindAsync(id);
        if (programmCarInnovation == null)
        {
            return NotFound(new { message = "ProgrammCarInnovation not found." });
        }
        return Ok(programmCarInnovation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgrammCarInnovation([FromBody] ProgrammCarInnovation programmCarInnovation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.ProgrammCarInnovations.Add(programmCarInnovation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProgrammCarInnovation), new { id = programmCarInnovation.Id }, programmCarInnovation);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var programmCarInnovation = await _context.ProgrammCarInnovations.FindAsync(id);
        if (programmCarInnovation == null)
        {
            return NotFound(new { message = "ProgrammCarInnovation not found." });
        }

        programmCarInnovation.IsActive = !programmCarInnovation.IsActive;
        await _context.SaveChangesAsync();

        return Ok(programmCarInnovation);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProgrammCarInnovation(int id, [FromBody] ProgrammCarInnovation programmCarInnovation)
    {
        if (id != programmCarInnovation.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingProgrammCarInnovation = await _context.ProgrammCarInnovations.FindAsync(id);
        if (existingProgrammCarInnovation == null)
        {
            return NotFound(new { message = "ProgrammCarInnovation not found." });
        }

        existingProgrammCarInnovation.ProgrammId = programmCarInnovation.ProgrammId;
        existingProgrammCarInnovation.CarInnovationId = programmCarInnovation.CarInnovationId;

        _context.Entry(existingProgrammCarInnovation).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgrammCarInnovation(int id)
    {
        var programmCarInnovation = await _context.ProgrammCarInnovations.FindAsync(id);
        if (programmCarInnovation == null)
        {
            return NotFound(new { message = "ProgrammCarInnovation not found." });
        }

        _context.ProgrammCarInnovations.Remove(programmCarInnovation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
