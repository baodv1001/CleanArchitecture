using hrm_core.DomainModels;
using hrm_core.Helper;
using hrm_core.Interfaces.Requests.Users;
using hrm_core.Requests.Employees;
using hrm_core.Responses.Users;

namespace hrm_core.Interfaces.Services
{
    public interface IUserService
    {
        Task<B2CUser> BulkCreate(AppSettings config, Microsoft.Graph.GraphServiceClient graphClient, EmployeeCreateRequest employee);
        Task<UserGetResponse> GetUser(IUserGetRequest user);
        Task<User> Signup(IUserSignupRequest request);
    }
}
