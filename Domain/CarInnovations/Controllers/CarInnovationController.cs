using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.CarInnovations.Models;

namespace programming_work_backend.Domain.CarInnovations.Controllers;

[ApiController]
[Route("api/v1/car-innovations")]
public class CarInnovationsController(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetCarInnovations()
    {
        var carInnovations = await context.CarInnovations.ToListAsync();
        return Ok(carInnovations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarInnovation(int id)
    {
        var carInnovation = await context.CarInnovations.FindAsync(id);
        if (carInnovation == null)
        {
            return NotFound(new { message = "CarInnovation not found." });
        }
        return Ok(carInnovation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCarInnovation([FromBody] CarInnovation carInnovation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.CarInnovations.Add(carInnovation);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCarInnovation), new { id = carInnovation.Id }, carInnovation);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var carInnovation = await context.CarInnovations.FindAsync(id);
        if (carInnovation == null)
        {
            return NotFound(new { message = "CarInnovation not found." });
        }

        carInnovation.IsActive = !carInnovation.IsActive;
        await context.SaveChangesAsync();

        return Ok(carInnovation);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCarInnovation(int id, [FromBody] CarInnovation carInnovation)
    {
        if (id != carInnovation.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingCarInnovation = await context.CarInnovations.FindAsync(id);
        if (existingCarInnovation == null)
        {
            return NotFound(new { message = "CarInnovation not found." });
        }

        existingCarInnovation.Name = carInnovation.Name;
        existingCarInnovation.Description = carInnovation.Description;
        existingCarInnovation.Type = carInnovation.Type;
        existingCarInnovation.IsActive = carInnovation.IsActive;

        context.Entry(existingCarInnovation).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarInnovation(int id)
    {
        var carInnovation = await context.CarInnovations.FindAsync(id);
        if (carInnovation == null)
        {
            return NotFound(new { message = "CarInnovation not found." });
        }

        context.CarInnovations.Remove(carInnovation);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
