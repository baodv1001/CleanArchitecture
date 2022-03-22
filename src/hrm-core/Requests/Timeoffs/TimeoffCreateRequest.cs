using hrm_core.Interfaces.Requests.Timeoffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Requests.Timeoffs
{
    public class TimeoffCreateRequest : ITimeoffCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Guid> Approvers { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid RequestModelId { get; set; }
        public List<string> Attachments { get; set; }
        public List<DateoffCreateModel> Dateoffs { get; set; }
    }
}
