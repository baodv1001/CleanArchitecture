using hrm_core.Interfaces.Requests.Users;

namespace hrm_core.Requests.Users
{
    public class UserGetRequest : IUserGetRequest
    {
        public string Subject { get; set; }
    }
}
