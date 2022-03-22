namespace hrm_core.DomainModels
{
    public class RequestModel
    {
        public Guid RequestModelId { get; set; }
        public string Name { get; set; }
        public bool IsSendDirect { get; set; }
        public int Deadline { get; set; }
        public int DistanceDays { get; set; }
        public int LimitDays { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Approver> Approvers { get; set; }
        public virtual ICollection<Timeoff> Requests { get; set; }
    }
}