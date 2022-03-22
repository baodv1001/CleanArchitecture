using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Interfaces.Requests.Timeoffs
{
    public interface ITimeoffApproveRequest
    {
        public Guid UserId { get; set; }
        public Guid RequestId { get; set; }
        public string UpdatedDate { get; set; }
    }
}
