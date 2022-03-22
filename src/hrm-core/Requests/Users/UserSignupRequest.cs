using hrm_core.Interfaces.Requests.Users;

namespace hrm_core.Requests.Users
{
    public class UserSignupRequest : IUserSignupRequest
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ObjectId { get; set; }
        public string Client_id { get; set; }
    }
}
