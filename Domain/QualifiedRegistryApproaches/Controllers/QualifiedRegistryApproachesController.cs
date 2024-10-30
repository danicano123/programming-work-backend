using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.QualifiedRegistryApproaches.Models;

namespace programming_work_backend.Domain.QualifiedRegistryApproaches.Controllers;

[ApiController]
[Route("api/v1/qualified-registry-approaches")]
public class QualifiedRegistryApproachesController : ControllerBase
{
    private readonly DBContext _context;

    public QualifiedRegistryApproachesController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetQualifiedRegistryApproaches()
    {
        var qualifiedRegistryApproaches = await _context.QualifiedRegistryApproaches.ToListAsync();
        return Ok(qualifiedRegistryApproaches);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQualifiedRegistryApproach(int id)
    {
        var qualifiedRegistryApproach = await _context.QualifiedRegistryApproaches.FindAsync(id);
        if (qualifiedRegistryApproach == null)
        {
            return NotFound(new { message = "QualifiedRegistryApproach not found." });
        }
        return Ok(qualifiedRegistryApproach);
    }

    [HttpPost]
    public async Task<IActionResult> CreateQualifiedRegistryApproach([FromBody] QualifiedRegistryApproach qualifiedRegistryApproach)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.QualifiedRegistryApproaches.Add(qualifiedRegistryApproach);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetQualifiedRegistryApproach), new { id = qualifiedRegistryApproach.Id }, qualifiedRegistryApproach);
    }

    [HttpPost("toggle-is-active/{id}")]
    public async Task<IActionResult> ToggleIsActive(int id)
    {
        var qualifiedRegistryApproach = await _context.QualifiedRegistryApproaches.FindAsync(id);
        if (qualifiedRegistryApproach == null)
        {
            return NotFound(new { message = "QualifiedRegistryApproach not found." });
        }

        // Cambiar el valor de IsActive
        qualifiedRegistryApproach.IsActive = !qualifiedRegistryApproach.IsActive;

        // Guardar los cambios
        await _context.SaveChangesAsync();

        return Ok(qualifiedRegistryApproach);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateQualifiedRegistryApproach(int id, [FromBody] QualifiedRegistryApproach qualifiedRegistryApproach)
    {
        if (id != qualifiedRegistryApproach.Id)
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingQualifiedRegistryApproach = await _context.QualifiedRegistryApproaches.FindAsync(id);
        if (existingQualifiedRegistryApproach == null)
        {
            return NotFound(new { message = "QualifiedRegistryApproach not found." });
        }

        existingQualifiedRegistryApproach.QualifiedRegistryId = qualifiedRegistryApproach.QualifiedRegistryId;
        existingQualifiedRegistryApproach.ApproachId = qualifiedRegistryApproach.ApproachId;

        _context.Entry(existingQualifiedRegistryApproach).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQualifiedRegistryApproach(int id)
    {
        var qualifiedRegistryApproach = await _context.QualifiedRegistryApproaches.FindAsync(id);
        if (qualifiedRegistryApproach == null)
        {
            return NotFound(new { message = "QualifiedRegistryApproach not found." });
        }

        _context.QualifiedRegistryApproaches.Remove(qualifiedRegistryApproach);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
