using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.ProgrammPracticeStrategys.Models;

namespace programming_work_backend.Domain.ProgrammPracticeStrategys.Controllers;

[ApiController]
[Route("api/v1/programm-practice-strategys")]
public class ProgrammPracticeStrategysController : ControllerBase
{
    private readonly DBContext _context;

    public ProgrammPracticeStrategysController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProgrammPracticeStrategys()
    {
        var programmPracticeStrategys = await _context.ProgrammPracticeStrategys.ToListAsync();
        return Ok(programmPracticeStrategys);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgrammPracticeStrategy(int id)
    {
        var programmPracticeStrategy = await _context.ProgrammPracticeStrategys.FindAsync(id);
        if (programmPracticeStrategy == null)
        {
            return NotFound(new { message = "ProgrammPracticeStrategy not found." });
        }
        return Ok(programmPracticeStrategy);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgrammPracticeStrategy([FromBody] ProgrammPracticeStrategy programmPracticeStrategy)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.ProgrammPracticeStrategys.Add(programmPracticeStrategy);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProgrammPracticeStrategy), new { id = programmPracticeStrategy.Id }, programmPracticeStrategy);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var programmPracticeStrategy = await _context.ProgrammPracticeStrategys.FindAsync(id);
        if (programmPracticeStrategy == null)
        {
            return NotFound(new { message = "ProgrammPracticeStrategy not found." });
        }

        programmPracticeStrategy.IsActive = !programmPracticeStrategy.IsActive;
        await _context.SaveChangesAsync();

        return Ok(programmPracticeStrategy);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProgrammPracticeStrategy(int id, [FromBody] ProgrammPracticeStrategy programmPracticeStrategy)
    {
        if (id != programmPracticeStrategy.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingProgrammPracticeStrategy = await _context.ProgrammPracticeStrategys.FindAsync(id);
        if (existingProgrammPracticeStrategy == null)
        {
            return NotFound(new { message = "ProgrammPracticeStrategy not found." });
        }

        existingProgrammPracticeStrategy.ProgrammId = programmPracticeStrategy.ProgrammId;
        existingProgrammPracticeStrategy.PracticeStrategyId = programmPracticeStrategy.PracticeStrategyId;

        _context.Entry(existingProgrammPracticeStrategy).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgrammPracticeStrategy(int id)
    {
        var programmPracticeStrategy = await _context.ProgrammPracticeStrategys.FindAsync(id);
        if (programmPracticeStrategy == null)
        {
            return NotFound(new { message = "ProgrammPracticeStrategy not found." });
        }

        _context.ProgrammPracticeStrategys.Remove(programmPracticeStrategy);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
