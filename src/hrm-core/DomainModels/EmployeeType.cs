namespace hrm_core.DomainModels
{
    public class EmployeeType : BaseModel
    {
        public Guid EmployeeTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
