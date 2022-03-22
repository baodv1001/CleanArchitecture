using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface IPersonalService
    {
        Task<Personal> GetById(Guid id);
    }
}
