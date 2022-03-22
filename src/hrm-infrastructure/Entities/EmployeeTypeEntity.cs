using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class EmployeeTypeEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid EmployeeTypeId { get; set; }
        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
