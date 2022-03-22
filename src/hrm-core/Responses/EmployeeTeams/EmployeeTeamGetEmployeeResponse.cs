using hrm_core.Interfaces.Responses.EmployeeTeams;
using hrm_core.Responses.Teams;

namespace hrm_core.Responses.EmployeeTeams
{
    public class EmployeeTeamGetEmployeeResponse : IEmployeeTeamGetEmployeeResponse
    {

        public Guid TeamId { get; set; }
        public TeamGetEmployeeResponse Team { get; set; }
    }
}
