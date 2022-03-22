using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class DepartmentEnity : BaseEntity
    {
        [Key]
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<TeamEntity> Teams { get; set; }
    }
}
