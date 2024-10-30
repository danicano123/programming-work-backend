using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;
using programming_work_backend.Domain.PracticeStrategys.Models;

namespace programming_work_backend.Domain.ProgrammPracticeStrategys.Models
{
    public class ProgrammPracticeStrategy
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Programm")]
        public int ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        [ForeignKey("PracticeStrategy")]
        public int PracticeStrategyId { get; set; }
        public PracticeStrategy? PracticeStrategy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
