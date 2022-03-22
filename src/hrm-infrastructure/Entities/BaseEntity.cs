using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
