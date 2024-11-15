using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.QualifiedRegistries.Models;
using programming_work_backend.Domain.Approaches.Models;

namespace programming_work_backend.Domain.QualifiedRegistryApproaches.Models;

public class QualifiedRegistryApproach
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("QualifiedRegistry")]
    public int? QualifiedRegistryId { get; set; }

    [ForeignKey("Approach")]
    public int? ApproachId { get; set; }

    public QualifiedRegistry? QualifiedRegistry { get; set; }
    public Approach? Approach { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
}
