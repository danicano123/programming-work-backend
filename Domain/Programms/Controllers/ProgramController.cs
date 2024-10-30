using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.Programs.Controllers;

[ApiController]
[Route("api/v1/programs")]
public class ProgramsController : ControllerBase
{
    private readonly DBContext _context;

    public ProgramsController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPrograms()
    {
        var programs = await _context.Programs.ToListAsync();
        return Ok(programs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgram(int id)
    {
        var program = await _context.Programs.FindAsync(id);
        if (program == null)
        {
            return NotFound(new { message = "Program not found." });
        }
        return Ok(program);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] Programm program)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Programs.Add(program);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProgram), new { id = program.Id }, program);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var program = await _context.Programs.FindAsync(id);
        if (program == null)
        {
            return NotFound(new { message = "Program not found." });
        }

        program.IsActive = !program.IsActive;
        await _context.SaveChangesAsync();

        return Ok(program);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProgram(int id, [FromBody] Programm program)
    {
        if (id != program.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingProgram = await _context.Programs.FindAsync(id);
        if (existingProgram == null)
        {
            return NotFound(new { message = "Program not found." });
        }

        existingProgram.Name = program.Name;
        existingProgram.Type = program.Type;
        existingProgram.Level = program.Level;
        existingProgram.CreationDate = program.CreationDate;
        existingProgram.ClosingDate = program.ClosingDate;
        existingProgram.NumberCohorts = program.NumberCohorts;
        existingProgram.GraduatesCount = program.GraduatesCount;
        existingProgram.LastUpdateDate = program.LastUpdateDate;
        existingProgram.City = program.City;
        existingProgram.FacultyId = program.FacultyId;

        _context.Entry(existingProgram).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        var program = await _context.Programs.FindAsync(id);
        if (program == null)
        {
            return NotFound(new { message = "Program not found." });
        }

        _context.Programs.Remove(program);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
