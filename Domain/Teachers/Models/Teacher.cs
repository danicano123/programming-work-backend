using System;
using System.ComponentModel.DataAnnotations;

namespace programming_work_backend.Domain.Teachers.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; } // This could be 'Cedula' if it's a national ID

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Url]
        public string CvUrl { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; }

        [MaxLength(50)]
        public string Escalafon { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Profile { get; set; } = string.Empty;

        [MaxLength(50)]
        public string MinScienceCategory { get; set; } = string.Empty;

        [MaxLength(50)]
        public string MinScienceConvention { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Nationality { get; set; } = string.Empty;

        [MaxLength(100)]
        public string MainResearchLine { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

    }
}
