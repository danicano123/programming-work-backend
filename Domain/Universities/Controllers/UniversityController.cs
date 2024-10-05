using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Universities.Models;

namespace programming_work_backend.Domain.Universities.Controllers;

[ApiController]
[Route("api/v1/university")]
public class UniversitiesController(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetUniversities()
    {
        var universities = await context.Universities.ToListAsync();
        return Ok(universities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUniversity(int id)
    {
        var university = await context.Universities.FindAsync(id);
        if (university == null)
        {
            return NotFound(new { message = "University not found." });
        }
        return Ok(university);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniversity([FromBody] University university)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Universities.Add(university);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUniversity), new { id = university.Id }, university);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUniversity(int id, [FromBody] University university)
    {
        if (id != university.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingUniversity = await context.Universities.FindAsync(id);
        if (existingUniversity == null)
        {
            return NotFound(new { message = "University not found." });
        }

        existingUniversity.Name = university.Name;
        existingUniversity.Type = university.Type;
        existingUniversity.City = university.City;

        context.Entry(existingUniversity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        var university = await context.Universities.FindAsync(id);
        if (university == null)
        {
            return NotFound(new { message = "University not found." });
        }

        context.Universities.Remove(university);
        await context.SaveChangesAsync();

        return NoContent();
    }
}