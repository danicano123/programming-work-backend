using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.PracticeStrategys.Models;

namespace programming_work_backend.Domain.PracticeStrategys.Controllers;

[ApiController]
[Route("api/v1/practiceStrategy")]
public class PracticeStrategys(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetPracticeStrategys()
    {
        var practiceStrategys = await context.PracticeStrategys.ToListAsync();
        return Ok(practiceStrategys);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPracticeStrategy(int id)
    {
        var practiceStrategy = await context.PracticeStrategys.FindAsync(id);
        if (practiceStrategy == null)
        {
            return NotFound(new { message = "PracticeStrategy not found." });
        }
        return Ok(practiceStrategy);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePracticeStrategy([FromBody] PracticeStrategy practiceStrategy)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PracticeStrategys.Add(practiceStrategy);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPracticeStrategy), new { id = practiceStrategy.Id }, practiceStrategy);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePracticeStrategy(int id, [FromBody] PracticeStrategy practiceStrategy)
    {
        if (id != practiceStrategy.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingPracticeStrategy = await context.PracticeStrategys.FindAsync(id);
        if (existingPracticeStrategy == null)
        {
            return NotFound(new { message = "PracticeStrategy not found." });
        }
        
        existingPracticeStrategy.Id = practiceStrategy.Id;
        existingPracticeStrategy.Type_practice = practiceStrategy.Type_practice;
        existingPracticeStrategy.Name = practiceStrategy.Name;
        existingPracticeStrategy.Description = practiceStrategy.Description;

        context.Entry(existingPracticeStrategy).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePracticeStrategy(int id)
    {
        var practiceStrategy = await context.PracticeStrategys.FindAsync(id);
        if (practiceStrategy == null)
        {
            return NotFound(new { message = "practiceStrategy not found." });
        }

        context.PracticeStrategys.Remove(practiceStrategy);
        await context.SaveChangesAsync();

        return NoContent();
    }
}