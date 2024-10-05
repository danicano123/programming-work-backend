using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.NormativeAspects.Models;

namespace programming_work_backend.Domain.NormativeAspects.Controllers;

[ApiController]
[Route("api/v1/normative-aspects")]
public class NormativeAspects(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetNormativeAspects()
    {
        var normativeAspects = await context.NormativeAspects.ToListAsync();
        return Ok(normativeAspects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNormativeAspect(int id)
    {
        var normativeAspect = await context.NormativeAspects.FindAsync(id);
        if (normativeAspect == null)
        {
            return NotFound(new { message = "NormativeAspect not found." });
        }
        return Ok(normativeAspect);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNormativeAspect([FromBody] NormativeAspect normativeAspect)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NormativeAspects.Add(normativeAspect);  //por que me sale error en allied?
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetNormativeAspect), new { id = normativeAspect.Id }, normativeAspect);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var normativeAspect = await context.NormativeAspects.FindAsync(id);
        if (normativeAspect == null)
        {
            return NotFound(new { message = "NormativeAspect not found." });
        }

        // Cambiar el valor de IsActive
        normativeAspect.IsActive = !normativeAspect.IsActive;

        // Guardar los cambios
        await context.SaveChangesAsync();

        return Ok(normativeAspect);
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateNormativeAspect(int id, [FromBody] NormativeAspect normativeAspect)
    {
        if (id != normativeAspect.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingNormativeAspect = await context.NormativeAspects.FindAsync(id);
        if (existingNormativeAspect == null)
        {
            return NotFound(new { message = "NormativeAspect not found." });
        }

        existingNormativeAspect.Id = normativeAspect.Id;
        existingNormativeAspect.Type = normativeAspect.Type;
        existingNormativeAspect.Description = normativeAspect.Description;
        existingNormativeAspect.Source = normativeAspect.Source;

        context.Entry(existingNormativeAspect).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNormativeAspect(int id)
    {
        var normativeAspect = await context.NormativeAspects.FindAsync(id);
        if (normativeAspect == null)
        {
            return NotFound(new { message = "NormativeAspect not found." });
        }

        context.NormativeAspects.Remove(normativeAspect); //Por que me sale error?
        await context.SaveChangesAsync();

        return NoContent();
    }
}