using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.QualifiedRegistries.Models;
using programming_work_backend.Domain.Approaches.Models;

namespace programming_work_backend.Domain.QualifiedRegistryApproaches.Models;

public class QualifiedRegistryApproach
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int QualifiedRegistryId { get; set; }

    [Required]
    public int ApproachId { get; set; }

    [ForeignKey("QualifiedRegistryId")]
    public QualifiedRegistry? QualifiedRegistry { get; set; }

    [ForeignKey("ApproachId")]
    public Approach? Approach { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
}
