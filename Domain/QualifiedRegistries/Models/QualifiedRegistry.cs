using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.QualifiedRegistries.Models;

public class QualifiedRegistry
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CreditAmount { get; set; } = string.Empty;

    [Required]
    public string AcomHours { get; set; } = string.Empty;

    [Required]
    public string IndependentHours { get; set; } = string.Empty;

    [Required]
    public string Methodology { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string DurationYears { get; set; } = string.Empty;

    [Required]
    public string DurationSemesters { get; set; } = string.Empty;

    [Required]
    public string DegreeType { get; set; } = string.Empty;

    [ForeignKey("Programm")]
    public int ProgrammId { get; set; }
    public Programm? Programm { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
}
