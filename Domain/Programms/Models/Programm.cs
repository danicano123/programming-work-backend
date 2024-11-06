using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Faculties.Models;

namespace programming_work_backend.Domain.Programms.Models
{
    public class Programm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Level { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CreationDate { get; set; } = string.Empty; // varchar format

        [MaxLength(10)]
        public string ClosingDate { get; set; } = string.Empty; // varchar format

        [MaxLength(10)]
        public string NumberCohorts { get; set; } = string.Empty; // varchar format

        [MaxLength(10)]
        public string GraduatesCount { get; set; } = string.Empty; // varchar format

        [MaxLength(10)]
        public string LastUpdateDate { get; set; } = string.Empty; // varchar format

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
