namespace hrm_core.DomainModels
{
    public class Office : BaseModel
    {
        public Guid OfficeId { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
