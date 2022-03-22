namespace hrm_core.Interfaces.Requests.Offices
{
    public interface IOfficeCreateRequest
    {
        string Name { get; set; }
        string Area { get; set; }
    }
}
