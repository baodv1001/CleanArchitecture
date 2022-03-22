using hrm_core.Interfaces.Responses.Teams;

namespace hrm_core.Responses.Teams
{
    public class TeamGetEmployeeResponse : ITeamGetEmployeeResponse
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
