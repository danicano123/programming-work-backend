using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_work_backend.Data;
using programming_work_backend.Domain.TeacherPrograms.Models;

namespace programming_work_backend.Domain.TeacherPrograms.Controllers
{
    [ApiController]
    [Route("api/v1/teacher-programs")]
    public class TeacherProgramsController : ControllerBase
    {
        private readonly DBContext _context;

        public TeacherProgramsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherPrograms()
        {
            var teacherPrograms = await _context.TeacherPrograms.ToListAsync();
            return Ok(teacherPrograms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherProgram(int id)
        {
            var teacherProgram = await _context.TeacherPrograms.FindAsync(id);
            if (teacherProgram == null)
            {
                return NotFound(new { message = "TeacherProgram not found." });
            }
            return Ok(teacherProgram);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherProgram([FromBody] TeacherProgram teacherProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TeacherPrograms.Add(teacherProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacherProgram), new { id = teacherProgram.Id }, teacherProgram);
        }

        [HttpPost("toggle-is-active/{id}")]
        public async Task<IActionResult> ToggleIsActive(int id)
        {
            var teacherProgram = await _context.TeacherPrograms.FindAsync(id);
            if (teacherProgram == null)
            {
                return NotFound(new { message = "TeacherProgram not found." });
            }

            teacherProgram.IsActive = !teacherProgram.IsActive;
            await _context.SaveChangesAsync();

            return Ok(teacherProgram);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTeacherProgram(int id, [FromBody] TeacherProgram teacherProgram)
        {
            if (id != teacherProgram.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            var existingTeacherProgram = await _context.TeacherPrograms.FindAsync(id);
            if (existingTeacherProgram == null)
            {
                return NotFound(new { message = "TeacherProgram not found." });
            }

            existingTeacherProgram.TeacherId = teacherProgram.TeacherId;
            existingTeacherProgram.ProgrammId = teacherProgram.ProgrammId;
            existingTeacherProgram.Dedication = teacherProgram.Dedication;
            existingTeacherProgram.Modality = teacherProgram.Modality;
            existingTeacherProgram.StartDate = teacherProgram.StartDate;
            existingTeacherProgram.EndDate = teacherProgram.EndDate;

            _context.Entry(existingTeacherProgram).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherProgram(int id)
        {
            var teacherProgram = await _context.TeacherPrograms.FindAsync(id);
            if (teacherProgram == null)
            {
                return NotFound(new { message = "TeacherProgram not found." });
            }

            _context.TeacherPrograms.Remove(teacherProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
