using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Faculties.Models;

namespace programming_work_backend.Domain.Faculties.Controllers;

[ApiController]
[Route("api/v1/faculties")]
public class FacultiesController(DBContext context) : ControllerBase
{
    private readonly DBContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetFaculties()
    {
        var faculties = await _context.Faculties.ToListAsync();
        return Ok(faculties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFaculty(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty == null)
        {
            return NotFound(new { message = "Faculty not found." });
        }
        return Ok(faculty);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFaculty([FromBody] Faculty faculty)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Faculties.Add(faculty);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFaculty), new { id = faculty.Id }, faculty);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty == null)
        {
            return NotFound(new { message = "Faculty not found." });
        }

        faculty.IsActive = !faculty.IsActive;
        await _context.SaveChangesAsync();

        return Ok(faculty);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateFaculty(int id, [FromBody] Faculty faculty)
    {
        if (id != faculty.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingFaculty = await _context.Faculties.FindAsync(id);
        if (existingFaculty == null)
        {
            return NotFound(new { message = "Faculty not found." });
        }

        existingFaculty.Name = faculty.Name;
        existingFaculty.Type = faculty.Type;
        existingFaculty.FoundationDate = faculty.FoundationDate;
        existingFaculty.UniversityId = faculty.UniversityId;

        _context.Entry(existingFaculty).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFaculty(int id)
    {
        var faculty = await _context.Faculties.FindAsync(id);
        if (faculty == null)
        {
            return NotFound(new { message = "Faculty not found." });
        }

        _context.Faculties.Remove(faculty);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
