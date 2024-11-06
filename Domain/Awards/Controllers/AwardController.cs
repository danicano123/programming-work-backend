using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Awards.Models;

namespace programming_work_backend.Domain.Awards.Controllers;

[ApiController]
[Route("api/v1/awards")]
public class AwardsController : ControllerBase
{
    private readonly DBContext _context;

    public AwardsController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAwards()
    {
        var awards = await _context.Awards.ToListAsync();
        return Ok(awards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAward(int id)
    {
        var award = await _context.Awards.FindAsync(id);
        if (award == null)
        {
            return NotFound(new { message = "Award not found." });
        }
        return Ok(award);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAward([FromBody] Award award)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Awards.Add(award);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAward), new { id = award.Id }, award);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var award = await _context.Awards.FindAsync(id);
        if (award == null)
        {
            return NotFound(new { message = "Award not found." });
        }

        award.IsActive = !award.IsActive;
        await _context.SaveChangesAsync();

        return Ok(award);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAward(int id, [FromBody] Award award)
    {
        if (id != award.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingAward = await _context.Awards.FindAsync(id);
        if (existingAward == null)
        {
            return NotFound(new { message = "Award not found." });
        }

        existingAward.Name = award.Name;
        existingAward.Description = award.Description;
        existingAward.Date = award.Date;
        existingAward.GrantingEntity = award.GrantingEntity;
        existingAward.Country = award.Country;
        existingAward.ProgrammId = award.ProgrammId;
        existingAward.IsActive = award.IsActive;

        _context.Entry(existingAward).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAward(int id)
    {
        var award = await _context.Awards.FindAsync(id);
        if (award == null)
        {
            return NotFound(new { message = "Award not found." });
        }

        _context.Awards.Remove(award);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
