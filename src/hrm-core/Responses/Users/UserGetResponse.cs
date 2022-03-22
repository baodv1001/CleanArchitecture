using hrm_core.Interfaces.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.Users
{
    public class UserGetResponse : IUserGetResponse
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public int Role { get; set; }
    }
}
