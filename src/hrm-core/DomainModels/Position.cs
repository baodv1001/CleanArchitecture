namespace hrm_core.DomainModels
{
    public class Position : BaseModel
    {
        public Guid PositionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
