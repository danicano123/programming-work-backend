using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Alliances.Models;

namespace programming_work_backend.Domain.Alliances.Controllers;

[ApiController]
[Route("api/v1/alliances")]
public class AlliancesController : ControllerBase
{
    private readonly DBContext _context;

    public AlliancesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlliances()
    {
        var alliances = await _context.Alliances.ToListAsync();
        return Ok(alliances);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlliance(int id)
    {
        var alliance = await _context.Alliances.FindAsync(id);
        if (alliance == null)
        {
            return NotFound(new { message = "Alliance not found." });
        }
        return Ok(alliance);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlliance([FromBody] Alliance alliance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Alliances.Add(alliance);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAlliance), new { id = alliance.Id }, alliance);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var alliance = await _context.Alliances.FindAsync(id);
        if (alliance == null)
        {
            return NotFound(new { message = "Alliance not found." });
        }

        alliance.IsActive = !alliance.IsActive;
        await _context.SaveChangesAsync();

        return Ok(alliance);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAlliance(int id, [FromBody] Alliance alliance)
    {
        if (id != alliance.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingAlliance = await _context.Alliances.FindAsync(id);
        if (existingAlliance == null)
        {
            return NotFound(new { message = "Alliance not found." });
        }

        existingAlliance.ProgrammId = alliance.ProgrammId;
        existingAlliance.AlliedId = alliance.AlliedId;
        existingAlliance.TeacherId = alliance.TeacherId;
        existingAlliance.StartDate = alliance.StartDate;

        _context.Entry(existingAlliance).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlliance(int id)
    {
        var alliance = await _context.Alliances.FindAsync(id);
        if (alliance == null)
        {
            return NotFound(new { message = "Alliance not found." });
        }

        _context.Alliances.Remove(alliance);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
