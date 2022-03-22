using hrm_core.Interfaces.Requests.Departments;

namespace hrm_core.Requests.Departments
{
    public class DepartmentCreateRequest : IDepartmentCreateRequest
    {
        public string Name { get; set; }
    }
}
