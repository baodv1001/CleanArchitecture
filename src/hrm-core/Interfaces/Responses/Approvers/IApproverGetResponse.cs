using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Interfaces.Responses.Approvers
{
    public interface IApproverGetResponse
    {
        public Guid EmployeeId  { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
