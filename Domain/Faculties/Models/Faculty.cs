using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Universities.Models;

namespace programming_work_backend.Domain.Faculties.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        public DateTime FoundationDate { get; set; }

        [ForeignKey("University")]
        public int UniversityId { get; set; }
        public University? University { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
