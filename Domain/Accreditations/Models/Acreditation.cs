namespace programming_work_backend.Domain.Accreditations.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;

public class Acreditation
{
    [Key]
    public int Resolution { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Qualification { get; set; } = string.Empty;

    public string StartDate { get; set; } = string.Empty;

    public string EndDate { get; set; } = string.Empty;

    [ForeignKey("Programm")]
    public int? ProgrammId { get; set; }
    public Programm? Programm { get; set; }


    public bool IsActive { get; set; } = true;
}
