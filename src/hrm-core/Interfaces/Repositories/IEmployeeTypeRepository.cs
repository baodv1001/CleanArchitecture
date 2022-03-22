using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IEmployeeTypeRepository
    {
        Task<IEnumerable<EmployeeType>> GetAll();
        Task<EmployeeType> Create(EmployeeType department);
        Task<EmployeeType> GetById(Guid id);
    }
}
