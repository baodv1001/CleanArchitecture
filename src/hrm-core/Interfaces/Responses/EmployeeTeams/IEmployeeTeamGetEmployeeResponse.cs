using hrm_core.Responses.Teams;

namespace hrm_core.Interfaces.Responses.EmployeeTeams
{
    public interface IEmployeeTeamGetEmployeeResponse
    {
        TeamGetEmployeeResponse Team { get; set; }
        Guid TeamId { get; set; }
    }
}