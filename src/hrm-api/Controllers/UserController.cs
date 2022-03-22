using hrm_core.Interfaces.Requests.Users;
using hrm_core.Interfaces.Responses.Users;
using hrm_core.Interfaces.Services;
using hrm_core.Requests.Users;
using hrm_core.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpPost("Signup", Name = "User-Signup")]
        public async Task<ActionResult<UserSignupResponse>> Signup(IUserSignupRequest user)
        {

            var response = await _userService.Signup(user).ConfigureAwait(false);

            if (response.UserId == Guid.Empty)
            {
                return BadRequest();
            }

            var signupResponse = new UserSignupResponse() { Version = "1.0.0", Action = "Continue" };

            return Ok(signupResponse);
        }

        [HttpPost("GetUser", Name = "User-Get")]
        public async Task<ActionResult<IUserGetResponse>> GetUser(UserGetRequest user)
        {

            var response = await _userService.GetUser(user).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
