using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.Teachers.Models;

namespace programming_work_backend.Domain.Teachers.Controllers
{
    [ApiController]
    [Route("api/v1/teachers")]
    public class TeacherController(DBContext context) : ControllerBase
    {
        private readonly DBContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found." });
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
        }

        [HttpPost("toggle-is-active/{id}")]
        public async Task<IActionResult> ToggleIsActive(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found." });
            }

            // Cambiar el valor de IsActive
            teacher.IsActive = !teacher.IsActive;

            // Guardar los cambios
            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null)
            {
                return NotFound(new { message = "Teacher not found." });
            }

            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.Gender = teacher.Gender;
            existingTeacher.Position = teacher.Position;
            existingTeacher.DateOfBirth = teacher.DateOfBirth;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Phone = teacher.Phone;
            existingTeacher.CvUrl = teacher.CvUrl;
            existingTeacher.LastUpdated = teacher.LastUpdated;
            existingTeacher.Escalafon = teacher.Escalafon;
            existingTeacher.Profile = teacher.Profile;
            existingTeacher.MinScienceCategory = teacher.MinScienceCategory;
            existingTeacher.MinScienceConvention = teacher.MinScienceConvention;
            existingTeacher.Nationality = teacher.Nationality;
            existingTeacher.MainResearchLine = teacher.MainResearchLine;

            _context.Entry(existingTeacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound(new { message = "Teacher not found." });
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
