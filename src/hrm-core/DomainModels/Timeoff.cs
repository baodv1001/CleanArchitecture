namespace hrm_core.DomainModels
{
    public class Timeoff : BaseModel
    {
        public Guid RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string[] Attachments { get; set; }

        public Guid? RequestModelId { get; set; }
        public virtual RequestModel RequestModel { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<RequestDateoff> RequestDateoffs { get; set; }
    }
}
