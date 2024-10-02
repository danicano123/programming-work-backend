using System.ComponentModel.DataAnnotations;

namespace programming_work_backend.Domain.Approaches.Models;

public class Approach
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
