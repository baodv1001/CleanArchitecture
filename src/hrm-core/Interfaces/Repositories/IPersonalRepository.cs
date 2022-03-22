using hrm_core.Interfaces.Requests.Employees;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IPersonalRepository
    {
        Task<Personal> Create(Personal personal);
        Task<Personal> Find(Guid? id);
        Task<Personal> GetById(Guid id);
        Task Update(IEmployeeUpdateRequest request, Guid? personalId);
    }
}
