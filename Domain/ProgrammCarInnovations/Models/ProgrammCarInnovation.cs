using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using programming_work_backend.Domain.Programms.Models;
using programming_work_backend.Domain.CarInnovations.Models;

namespace programming_work_backend.Domain.ProgrammCarInnovations.Models
{
    public class ProgrammCarInnovation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Programm")]
        public int ProgrammId { get; set; }
        public Programm? Programm { get; set; }

        [ForeignKey("CarInnovation")]
        public int CarInnovationId { get; set; }
        public CarInnovation? CarInnovation { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
