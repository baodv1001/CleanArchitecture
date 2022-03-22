using hrm_core.Interfaces.Responses.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.Employees
{
    public class EmployeeGetAllResponse : IEmployeeGetAllResponse
    {
        public IEnumerable<EmployeeGetResponse> Employees { get; set; }
        public int Total { get; set; }
    }
}
