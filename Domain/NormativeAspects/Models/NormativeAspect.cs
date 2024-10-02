namespace programming_work_backend.Domain.NormativeAspects.Models;
using System.ComponentModel.DataAnnotations;

public class NormativeAspect
{

    [Key]
    public int Id { get; set; }
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Source { get; set; } = string.Empty;

}
