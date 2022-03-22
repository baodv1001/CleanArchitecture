using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> Create(Department department);
        Task<Department> GetById(Guid id);
    }
}
