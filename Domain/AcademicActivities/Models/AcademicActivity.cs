using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_work_backend.Domain.AcademicActivities.Models;

public class AcademicActivity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Credits { get; set; }

    public string Type { get; set; } = string.Empty;

    public string TrainingArea { get; set; } = string.Empty;

    public int HAcom { get; set; }  // Hacom in camel case

    public int HIndep { get; set; }  // Hindep in camel case

    public string Language { get; set; } = string.Empty;

    public short Mirror { get; set; }  // Mirror (Espejo) as TinyInt

    public string MirrorEntity { get; set; } = string.Empty;

    public string MirrorCountry { get; set; } = string.Empty;

    [ForeignKey("Programm")]  // Foreign key points to 'Programm'
    public int? ProgrammId { get; set; }  // Foreign key (correctly placed here)

    public bool IsActive { get; set; } = true;
}
