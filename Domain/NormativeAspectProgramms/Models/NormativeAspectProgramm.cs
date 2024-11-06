using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.NormativeAspects.Models;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.NormativeAspectProgramms.Models
{
    public class NormativeAspectProgramm
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NormativeAspect")]
        public int? NormativeAspectId { get; set; }
        public NormativeAspect? NormativeAspect { get; set; }

        [ForeignKey("Programm")]
        public int? ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
