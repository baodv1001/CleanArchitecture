using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class EmployeeTeamRepository : IEmployeeTeamRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeTeamRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeTeam> Create(EmployeeTeam employeeTeam)
        {
            var dbEmployeeTeam = _mapper.Map<EmployeeTeamEntity>(employeeTeam);
            _dbContext.EmployeeTeams.Add(dbEmployeeTeam);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeTeam>(dbEmployeeTeam);
        }

        public async Task<bool> ExistEmployeeTeam(Guid teamId, Guid employeeId)
        {
            var db = await _dbContext.EmployeeTeams.Where(et => et.TeamId == teamId && et.EmployeeId == employeeId).ToListAsync().ConfigureAwait(false);
            if (db.Count == 0)
            {
                return false;
            }
            return true;
        }

        public async Task Delete(Guid teamId, Guid employeeId)
        {
            var dbEmployeeTeam = await _dbContext.EmployeeTeams.Where(et => et.TeamId == teamId && et.EmployeeId == employeeId).FirstOrDefaultAsync();

            _dbContext.EmployeeTeams.Remove(dbEmployeeTeam);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeTeam>> GetListTeamByEmpId(Guid employeeId)
        {
            var dbEmployeeTeams = await _dbContext.EmployeeTeams.Where(et => et.EmployeeId == employeeId).ToListAsync();

            return _mapper.Map<List<EmployeeTeam>>(dbEmployeeTeams);
        }
    }
}
