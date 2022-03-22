using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class TeamEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? DepartmentId { get; set; }
        public virtual DepartmentEnity Department { get; set; }

        public Guid? ManagerId { get; set; }
        public virtual EmployeeEntity Manager { get; set; }

        public virtual ICollection<EmployeeTeamEntity> EmployeeTeams { get; set; }
    }
}
