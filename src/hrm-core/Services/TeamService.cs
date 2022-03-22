using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Teams;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using Microsoft.Extensions.Logging;

namespace hrm_core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ILogger<TeamService> _logger;
        private readonly ITeamRepository _teamRepository;

        public TeamService(ILogger<TeamService> logger, ITeamRepository teamRepository)
        {
            _logger = logger;
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamRepository.GetAll();
        }

        public async Task<Team> Create(ITeamCreateRequest team)
        {
            var newTeam = new Team()
            {
                TeamId = Guid.NewGuid(),
                Name = team.Name,
                DepartmentId = team.DepartmentId,
                Description = team.Description,
                ManagerId = team.ManagerId,

                CreatedDate = DateTime.Now,
                CreatedBy = "Postman"
            };
            return await _teamRepository.Create(newTeam);
        }

        public async Task<Team> GetById(Guid id)
        {
            return await _teamRepository.GetById(id);
        }
    }
}
