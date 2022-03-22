using hrm_core.Responses.Approvers;
using hrm_core.Responses.Dateoffs;
using hrm_core.Responses.RequestDateoffs;

namespace hrm_core.Interfaces.Responses.Requests
{
    public interface IRequestGetResponse
    {
        public Guid RequestId { get; set; }
        public Guid RequestModelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequestModelName { get; set; }
        public int Deadline { get; set; }
        public int DistanceDays { get; set; }
        public int LimitDays { get; set; }
        public int Status { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ICollection<DateoffGetResponse> RequestDateoffs { get; set; }

        public ICollection<ApproverGetResponse> Approvers { get; set; }

    }
}
