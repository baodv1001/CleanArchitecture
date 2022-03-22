using hrm_core.Interfaces.Requests.Employees;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Responses.Employees;

namespace hrm_core.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeGetAllResponse> GetAll(EmployeeGetAllParameters employeeParameters);
        Task<Employee> Create(Employee employee);
        Task<EmployeeGetResponse> GetById(Guid id);
        Task<Employee> Update(IEmployeeUpdateRequest employee, Guid employeeId);
        Task<Employee> Find(Guid id);
        Task<bool> UpdateAvatar(string url, Guid employeeId);
        Task<Employee> Delete(Guid id);
    }
}
