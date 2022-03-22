namespace hrm_core.Interfaces.Requests.Teams
{
    public interface ITeamCreateRequest
    {
        string Name { get; set; }
        string Description { get; set; }
        Guid DepartmentId { get; set; }
        Guid? ManagerId { get; set; }
    }
}
