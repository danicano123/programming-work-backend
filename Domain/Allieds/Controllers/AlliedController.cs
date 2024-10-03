using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Allieds.Models;

namespace programming_work_backend.Domain.Allieds.Controllers;

[ApiController]
[Route("api/v1/allied")]
public class Allieds(DBContext context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllieds()
    {
        var allieds = await context.Allieds.ToListAsync();
        return Ok(allieds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllied(int id)
    {
        var allied = await context.Allieds.FindAsync(id);
        if (allied == null)
        {
            return NotFound(new { message = "Allied not found." });
        }
        return Ok(allied);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAllied([FromBody] Allied allied)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Allieds.Add(allied);  //por que me sale error en allied?
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllied), new { id = allied.Id }, allied);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAllied(int id, [FromBody] Allied allied) 
    {
        if (id != allied.Id) 
        {
            return BadRequest(new { message = "ID mismatch." });
        }

        var existingAllied = await context.Allieds.FindAsync(id);
        if (existingAllied == null)
        {
            return NotFound(new { message = "Allied not found." });
        }
        
        existingAllied.Id = allied.Id;
        existingAllied.Company_reason = allied.Company_reason;   
        existingAllied.Contact_name = allied.Contact_name;
        existingAllied.Phone = allied.Phone;
        existingAllied.City = allied.City;

        context.Entry(existingAllied).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAllied(int id)
    {
        var allied = await context.Allieds.FindAsync(id);
        if (allied == null)
        {
            return NotFound(new { message = "Allied not found." });
        }

        context.Allieds.Remove(allied);
        await context.SaveChangesAsync();

        return NoContent();
    }
}