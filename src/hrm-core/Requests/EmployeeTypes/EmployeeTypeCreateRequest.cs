using hrm_core.Interfaces.Requests.EmployeeTypes;

namespace hrm_core.Requests.EmployeeTypes
{
    public class EmployeeTypeCreateRequest : IEmployeeTypeCreateRequest
    {
        public string TypeName { get; set; }
    }
}
