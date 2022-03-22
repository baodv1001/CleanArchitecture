using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IDateoffRepository
    {
        Task<bool> Create(List<Dateoff> dateoffs);

    }
}
