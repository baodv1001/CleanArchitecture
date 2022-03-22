using hrm_core.Interfaces.Requests.Teams;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface ITeamService
    {
        Task<Team> Create(ITeamCreateRequest request);
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(Guid id);
    }
}
