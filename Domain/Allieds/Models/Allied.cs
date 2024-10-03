namespace programming_work_backend.Domain.Allieds.Models;
using System.ComponentModel.DataAnnotations;

public class Allied
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Company_reason { get; set; } = string.Empty;
    [Required]
    public string Contact_name { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;

}
