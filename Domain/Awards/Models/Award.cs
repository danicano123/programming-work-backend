using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;

namespace programming_work_backend.Domain.Awards.Models;

public class Award
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string GrantingEntity { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    [ForeignKey("Programm")]
    public int ProgrammId { get; set; }

    public Programm? Programm { get; set; }

    public bool IsActive { get; set; } = true;
}
