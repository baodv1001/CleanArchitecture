using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IRequestDateoffRepository
    {
        Task<bool> Create(List<RequestDateoff> dateoffs);
    }
}
