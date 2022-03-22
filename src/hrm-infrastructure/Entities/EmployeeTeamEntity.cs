using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class EmployeeTeamEntity
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        [Key]
        public Guid TeamId { get; set; }
        public virtual TeamEntity Team { get; set; }
    }
}
