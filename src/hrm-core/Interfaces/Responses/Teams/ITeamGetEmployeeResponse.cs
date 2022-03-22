namespace hrm_core.Interfaces.Responses.Teams
{
    public interface ITeamGetEmployeeResponse
    {
        Guid TeamId { get; set; }
        string Name { get; set; }
        Guid? DepartmentId { get; set; }
    }
}
