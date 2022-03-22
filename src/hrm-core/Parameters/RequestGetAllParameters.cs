using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Parameters
{
    public class RequestGetAllParameters : QueryStringParamters
    {
        public Guid RequestModelId { get; set; }
        public int Status { get; set; } = 1;

    }
}
