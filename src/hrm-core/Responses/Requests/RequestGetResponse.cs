using hrm_core.Interfaces.Responses.Requests;
using hrm_core.DomainModels;
using hrm_core.Responses.Approvers;
using hrm_core.Responses.Dateoffs;
using hrm_core.Responses.RequestDateoffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.Requests
{
    public class RequestGetResponse : IRequestGetResponse
    {
        public Guid RequestId { get ; set ; }
        public Guid RequestModelId { get ; set ; }
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public string RequestModelName { get ; set ; }
        public int Status { get ; set ; }
        public Guid EmployeeId { get ; set ; }
        public string EmployeeName { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public ICollection<DateoffGetResponse> RequestDateoffs { get ; set ; }
        public int Deadline { get ; set ; }
        public int DistanceDays { get ; set ; }
        public int LimitDays { get ; set ; }
        public ICollection<ApproverGetResponse> Approvers { get ; set ; }
    }
}
