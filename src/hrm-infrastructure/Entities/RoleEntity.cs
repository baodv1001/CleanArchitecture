using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class RoleEntity
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleNum { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
