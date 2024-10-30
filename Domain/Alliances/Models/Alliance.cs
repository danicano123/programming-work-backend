using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Teachers.Models;
using programming_work_backend.Domain.Programms.Models;
using programming_work_backend.Domain.Allieds.Models;

namespace programming_work_backend.Domain.Alliances.Models
{
    public class Alliance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Programm")]
        public int ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        [ForeignKey("Allied")]
        public int AlliedId { get; set; }
        public Allied? Allied { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
