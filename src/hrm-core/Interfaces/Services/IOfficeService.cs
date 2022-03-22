using hrm_core.Interfaces.Requests.Offices;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface IOfficeService
    {
        Task<Office> Create(IOfficeCreateRequest request);
        Task<IEnumerable<Office>> GetAll();
        Task<Office> GetById(Guid id);
    }
}
