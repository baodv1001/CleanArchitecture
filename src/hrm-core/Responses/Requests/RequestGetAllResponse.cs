using hrm_core.Interfaces.Responses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.Requests
{
    public class RequestGetAllResponse 
    {
        public IEnumerable<IRequestGetResponse> Requests { get; set; }
        public int Total { get; set; }
    }
}
