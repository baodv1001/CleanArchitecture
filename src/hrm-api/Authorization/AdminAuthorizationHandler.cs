using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace hrm_api.Authorization
{
    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        public AdminAuthorizationHandler(IHttpContextAccessor contextAccessor, IUserRepository userRepository)
            : base()
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            var claims = _contextAccessor.HttpContext.User.Identities.First().Claims.ToList();

            if (claims.Count == 0)
            {
                return Task.CompletedTask;
            }

            var usSubject = claims?.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.OrdinalIgnoreCase))?.Value;

            var usRole = _userRepository.GetRole(usSubject);

            if (usRole == RoleType.ADMIN || usRole == RoleType.LEADER)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement(string role)
        {
            _role = role;
        }
        public string _role { get; private set; }
    }
}
