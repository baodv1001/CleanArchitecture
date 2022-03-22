using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Net;
using System.Text;

namespace hrm_api.Authorization
{
    public class AuthorizationResultTransformer : IAuthorizationMiddlewareResultHandler
    {
        private readonly IAuthorizationMiddlewareResultHandler _handler;

        public AuthorizationResultTransformer()
        {
            _handler = new AuthorizationMiddlewareResultHandler();
        }

        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Forbidden &&
                authorizeResult.AuthorizationFailure != null &&
                authorizeResult.AuthorizationFailure.FailedRequirements.Any(requirement => requirement is AdminRequirement))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var bytes = Encoding.UTF8.GetBytes("You don't have permission to access this content!");
                await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                return;
                // Other transformations here
            }

            await _handler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
