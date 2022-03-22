namespace hrm_core.DomainModels
{
    public class Department : BaseModel
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
