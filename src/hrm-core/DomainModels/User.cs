namespace hrm_core.DomainModels
{
    public class User
    {

        public Guid UserId { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
    
}
