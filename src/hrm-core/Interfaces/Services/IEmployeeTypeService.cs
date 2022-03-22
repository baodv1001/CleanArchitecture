using hrm_core.Interfaces.Requests.EmployeeTypes;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface IEmployeeTypeService
    {
        Task<EmployeeType> Create(IEmployeeTypeCreateRequest employeeType);
        Task<IEnumerable<EmployeeType>> GetAll();
        Task<EmployeeType> GetById(Guid id);
    }
}
