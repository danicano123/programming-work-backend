using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Accreditations.Models;

namespace programming_work_backend.Domain.Accreditations.Controllers;

[ApiController]
[Route("api/v1/accreditations")]
public class AcreditationsController(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAcreditations()
    {
        var accreditations = await context.Accreditations.ToListAsync();
        return Ok(accreditations);
    }

    [HttpGet("{resolution}")]
    public async Task<IActionResult> GetAcreditation(int resolution)
    {
        var accreditation = await context.Accreditations.FindAsync(resolution);
        if (accreditation == null)
        {
            return NotFound(new { message = "Acreditation not found." });
        }
        return Ok(accreditation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAcreditation([FromBody] Acreditation accreditation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Accreditations.Add(accreditation);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAcreditation), new { resolution = accreditation.Resolution }, accreditation);
    }

    [HttpPost("toggle-is-active/{resolution}")]
    public async Task<IActionResult> ToggleIsActive(int resolution)
    {
        var accreditation = await context.Accreditations.FindAsync(resolution);
        if (accreditation == null)
        {
            return NotFound(new { message = "Acreditation not found." });
        }

        accreditation.IsActive = !accreditation.IsActive;
        await context.SaveChangesAsync();

        return Ok(accreditation);
    }

    [HttpPatch("{resolution}")]
    public async Task<IActionResult> UpdateAcreditation(int resolution, [FromBody] Acreditation accreditation)
    {
        if (resolution != accreditation.Resolution)
        {
            return BadRequest(new { message = "Resolution mismatch." });
        }

        var existingAcreditation = await context.Accreditations.FindAsync(resolution);
        if (existingAcreditation == null)
        {
            return NotFound(new { message = "Acreditation not found." });
        }

        existingAcreditation.Type = accreditation.Type;
        existingAcreditation.Qualification = accreditation.Qualification;
        existingAcreditation.StartDate = accreditation.StartDate;
        existingAcreditation.EndDate = accreditation.EndDate;
        existingAcreditation.ProgrammId = accreditation.ProgrammId;
        existingAcreditation.IsActive = accreditation.IsActive;

        context.Entry(existingAcreditation).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{resolution}")]
    public async Task<IActionResult> DeleteAcreditation(int resolution)
    {
        var accreditation = await context.Accreditations.FindAsync(resolution);
        if (accreditation == null)
        {
            return NotFound(new { message = "Acreditation not found." });
        }

        context.Accreditations.Remove(accreditation);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
