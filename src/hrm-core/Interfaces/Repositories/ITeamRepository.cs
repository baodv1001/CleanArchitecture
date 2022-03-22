using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> Create(Team team);
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(Guid id);
    }
}
