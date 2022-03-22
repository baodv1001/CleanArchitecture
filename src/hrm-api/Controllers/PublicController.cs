using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    [Authorize(Policy = "AdminRequire")]
    [ApiController]
    [Route("[controller]")]
    public class PublicController : ControllerBase
    {
        public PublicController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { name = User.Identity.Name });
        }
    }
}