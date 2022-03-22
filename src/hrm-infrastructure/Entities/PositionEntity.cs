using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class PositionEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid PositionId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
