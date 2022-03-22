namespace hrm_core.DomainModels
{
    public class EmployeeTeam
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
