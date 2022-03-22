using hrm_core.Interfaces.Responses.Users;

namespace hrm_core.Responses.Users
{
    public class UserSignupResponse : IUserSignupResponse
    {
        public string Version { get; set; }
        public string Action { get; set; }
    }
}
