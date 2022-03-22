namespace hrm_core.DomainModels
{
    public class Approver
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public Guid RequestModelId { get; set; }
        public virtual RequestModel RequestModel { get; set; }
    }
}