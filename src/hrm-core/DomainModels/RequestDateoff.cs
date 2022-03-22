namespace hrm_core.DomainModels
{
    public class RequestDateoff
    {
        public Guid RequestId { get; set; }
        public virtual Timeoff Timeoff { get; set; }

        public Guid DateoffId { get; set; }
        public virtual Dateoff Dateoff { get; set; }
    }
}