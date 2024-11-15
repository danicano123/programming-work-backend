using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.AcademicActivities.Models;
using programming_work_backend.Domain.QualifiedRegistries.Models;

namespace programming_work_backend.Domain.QualifiedRegistryAcademicActivities.Models
{
    public class QualifiedRegistryAcademicActivity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QualifiedRegistry")]
        public int? QualifiedRegistryId { get; set; }  // FK to 'QualifiedRegistry'

        public QualifiedRegistry? QualifiedRegistry { get; set; }

        [ForeignKey("AcademicActivity")]
        public int? AcademicActivityId { get; set; }  // FK to 'AcademicActivity'

        public AcademicActivity? AcademicActivity { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
