using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.Internships.Models
{
    public class Internship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public string Company { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("Programm")]
        public int ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
