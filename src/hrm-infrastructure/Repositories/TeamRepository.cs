using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public TeamRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            var teams = await _dbContext.Teams.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Team>>(teams);
        }

        public async Task<Team> Create(Team team)
        {
            var dbTeam = _mapper.Map<TeamEntity>(team);
            _dbContext.Teams.Add(dbTeam);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Team>(dbTeam);
        }

        public async Task<Team> GetById(Guid id)
        {
            var team = await _dbContext.Teams.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<Team>(team);
        }
    }
}