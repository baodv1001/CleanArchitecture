using hrm_core.DomainModels;
using hrm_core.Interfaces.Requests.Employees;
using hrm_core.Parameters;
using hrm_core.Responses.Employees;
using System;

namespace hrm_core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeGetAllResponse> GetAll(EmployeeGetAllParameters employeeParameters);
        Task<EmployeeGetResponse> GetById(Guid id);
        Task<Employee> Update(Guid id, IEmployeeUpdateRequest request);
        Task<bool> UpdateAvatar(string url, Guid employeeId);
        Task<Employee> Delete(Guid id);
        Task<Employee> Create(IEmployeeCreateRequest employee, B2CUser user);
    }
}
