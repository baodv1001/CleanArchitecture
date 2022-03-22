using AutoMapper;
using hrm_core.DomainModels;
using hrm_core.Helper;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Users;
using hrm_core.Interfaces.Responses.Users;
using hrm_core.Interfaces.Services;
using hrm_core.Requests.Employees;
using hrm_core.Responses.Users;
using Microsoft.Graph;

namespace hrm_core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DomainModels.User> Signup(IUserSignupRequest user)
        {
            var newUser = new DomainModels.User()
            {
                UserId = Guid.NewGuid(),
                Email = user.Email,
                RoleId = new Guid("96BDCB87-5F30-4121-9E1C-807B38E97AD6"),
                Subject = user.ObjectId
            };

            return await _userRepository.Signup(newUser);
        }

        public async Task<UserGetResponse> GetUser(IUserGetRequest user)
        {
            var rsUser = await _userRepository.GetUser(user.Subject);

            if (rsUser == null)
            {
                //Create new User
            }
            return _mapper.Map<UserGetResponse>(rsUser);
            
        }

        public async Task<B2CUser> BulkCreate(AppSettings config, GraphServiceClient graphClient, EmployeeCreateRequest employee)
        {
            var issuerId = employee.FirstName  + employee.LastName+"@logixtek.com";
            var password = employee.FirstName + employee.LastName + "@logixtek";
            var displayName = employee.FirstName + employee.LastName;

            var identities = new List<ObjectIdentity>() { new ObjectIdentity { SignInType = "emailAddress", IssuerAssignedId = issuerId } };

            B2CUser newUser = new B2CUser() { DisplayName = displayName, Identities = identities, Password = password };
            newUser.SetB2CProfile(config.TenantId);

            try
            {
                Microsoft.Graph.User resUser = await graphClient.Users
                                                .Request()
                                                .AddAsync(newUser);
                newUser.Subject = resUser.Id;
                return newUser;
            }
            catch
            {
                return null;
            }
        }

    }
}
