namespace programming_work_backend.Domain.CarInnovations.Models;
using System.ComponentModel.DataAnnotations;

public class CarInnovation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;
}
