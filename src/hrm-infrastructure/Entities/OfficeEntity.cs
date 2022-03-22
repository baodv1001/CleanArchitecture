using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class OfficeEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Area { get; set; }

        public virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
