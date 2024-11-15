using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Teachers.Models;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.TeacherPrograms.Models
{
    public class TeacherProgram
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        [ForeignKey("Programm")]
        public int? ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        public string Dedication { get; set; } = string.Empty;
        public string Modality { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
