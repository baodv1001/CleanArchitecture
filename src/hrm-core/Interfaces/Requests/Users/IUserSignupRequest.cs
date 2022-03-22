namespace hrm_core.Interfaces.Requests.Users
{
    public interface IUserSignupRequest
    {
        string Email { get; set; }
        string DisplayName { get; set; }
        string ObjectId { get; set; }
        string Client_id { get; set; }
    }
}
