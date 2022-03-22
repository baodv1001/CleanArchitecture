using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IEmployeeTeamRepository
    {
        Task<EmployeeTeam> Create(EmployeeTeam employeeTeam);
        Task Delete(Guid teamId, Guid employeeId);
        Task<bool> ExistEmployeeTeam(Guid teamId, Guid employeeId);
        Task<List<EmployeeTeam>> GetListTeamByEmpId(Guid employeeId);
    }
}
