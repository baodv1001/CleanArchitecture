namespace hrm_core.DomainModels
{
    public class Team : BaseModel
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
    }
}
