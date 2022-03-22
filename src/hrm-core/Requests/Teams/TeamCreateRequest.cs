using hrm_core.Interfaces.Requests.Teams;

namespace hrm_core.Requests.Teams
{
    public class TeamCreateRequest : ITeamCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
