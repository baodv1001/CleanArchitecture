using hrm_core.Enums;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        RoleType GetRole(string Email);
        Task<User> GetUser(string subject);
        Task<User> Signup(User user);
    }
}
