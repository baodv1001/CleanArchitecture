using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class UserEntity
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        //ObjectID == UserID of Azure
        public string Subject { get; set; }

        [Required]
        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }

        public Guid? EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
    }
}
