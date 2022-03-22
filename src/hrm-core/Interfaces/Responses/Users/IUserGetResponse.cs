namespace hrm_core.Interfaces.Responses.Users
{
    public interface IUserGetResponse
    {
        string Email { get; set; }
        string Subject { get; set; }
        int Role { get; set; }
    }
}
