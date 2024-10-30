using System.ComponentModel.DataAnnotations;

namespace programming_work_backend.Domain.PracticeStrategys.Models;

public class PracticeStrategy
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Type_practice { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public bool IsActive { get; set; } = true;

}