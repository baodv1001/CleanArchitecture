using hrm_core.Interfaces.Requests.Timeoffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Requests.Timeoffs
{
    public class TimeoffApproveRequest : ITimeoffApproveRequest
    {
        public Guid UserId { get; set; }
        public Guid RequestId { get ; set ; }
        public string UpdatedDate { get ; set ; }
    }
}
