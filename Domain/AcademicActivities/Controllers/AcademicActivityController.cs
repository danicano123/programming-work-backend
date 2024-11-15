using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.AcademicActivities.Models;

namespace programming_work_backend.Domain.AcademicActivities.Controllers;

[ApiController]
[Route("api/v1/academic-activities")]
public class AcademicActivitiesController : ControllerBase
{
    private readonly DBContext _context;

    public AcademicActivitiesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAcademicActivities()
    {
        var academicActivities = await _context.AcademicActivities.ToListAsync();
        return Ok(academicActivities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAcademicActivity(int id)
    {
        var academicActivity = await _context.AcademicActivities.FindAsync(id);
        if (academicActivity == null)
        {
            return NotFound(new { message = "AcademicActivity not found." });
        }
        return Ok(academicActivity);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAcademicActivity([FromBody] AcademicActivity academicActivity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.AcademicActivities.Add(academicActivity);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAcademicActivity), new { id = academicActivity.Id }, academicActivity);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAcademicActivity(int id, [FromBody] AcademicActivity academicActivity)
    {
        if (id != academicActivity.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingAcademicActivity = await _context.AcademicActivities.FindAsync(id);
        if (existingAcademicActivity == null)
        {
            return NotFound(new { message = "AcademicActivity not found." });
        }

        existingAcademicActivity.Name = academicActivity.Name;
        existingAcademicActivity.Credits = academicActivity.Credits;
        existingAcademicActivity.Type = academicActivity.Type;
        existingAcademicActivity.TrainingArea = academicActivity.TrainingArea;
        existingAcademicActivity.HAcom = academicActivity.HAcom;
        existingAcademicActivity.HIndep = academicActivity.HIndep;
        existingAcademicActivity.Language = academicActivity.Language;
        existingAcademicActivity.Mirror = academicActivity.Mirror;
        existingAcademicActivity.MirrorEntity = academicActivity.MirrorEntity;
        existingAcademicActivity.MirrorCountry = academicActivity.MirrorCountry;
        existingAcademicActivity.ProgrammId = academicActivity.ProgrammId;
        existingAcademicActivity.IsActive = academicActivity.IsActive;

        _context.Entry(existingAcademicActivity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAcademicActivity(int id)
    {
        var academicActivity = await _context.AcademicActivities.FindAsync(id);
        if (academicActivity == null)
        {
            return NotFound(new { message = "AcademicActivity not found." });
        }

        _context.AcademicActivities.Remove(academicActivity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
