using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class CodeEntity
    {
        [Key]
        [Required]
        public Guid CodeId { get; set; }

        public int EmployeeNum { get; set; }
    }
}
