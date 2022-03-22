using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hrm_api.Authorization
{
    public class AppAuthorize : ActionFilterAttribute
    {
        public RoleType[] AllowedRoles { get; set; }
        public AppAuthorize()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();

            var claims = context.HttpContext.User.Identities.First().Claims.ToList();

            if (claims.Count == 0)
            {
                context.Result = new ObjectResult("Forbidden") { StatusCode = 403 };
            }

            var usSubject = claims?.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.OrdinalIgnoreCase))?.Value;

            var usRole = _userRepository.GetRole(usSubject);

            if (IsAuthorized(usRole))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ObjectResult("Forbidden") { StatusCode = 403 };
            }
        }
        public bool IsAuthorized(RoleType userRole)
        {
            foreach (var role in AllowedRoles)
            {
                if (userRole == role)
                    return true;
            }
            return false;
        }
    }
}
