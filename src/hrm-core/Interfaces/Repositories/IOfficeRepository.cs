using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IOfficeRepository
    {
        Task<Office> Create(Office office);
        Task<IEnumerable<Office>> GetAll();
        Task<Office> GetById(Guid id);
    }
}
