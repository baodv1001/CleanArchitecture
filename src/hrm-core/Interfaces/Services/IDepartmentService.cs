using hrm_core.Interfaces.Requests.Departments;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<Department> Create(IDepartmentCreateRequest department);
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(Guid id);
    }
}
