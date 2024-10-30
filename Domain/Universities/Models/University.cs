using System.ComponentModel.DataAnnotations;

namespace programming_work_backend.Domain.Universities.Models;

public class University
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    [Required]
    public bool IsActive { get; set; } = true;

}
