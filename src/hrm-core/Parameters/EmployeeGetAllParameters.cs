using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Parameters
{
    public class EmployeeGetAllParameters : QueryStringParamters
    {
        public int Status { get; set; } = 1;
        public string Name { get; set; } = "";  
    }
}
