namespace hrm_core.DomainModels
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleNum { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
