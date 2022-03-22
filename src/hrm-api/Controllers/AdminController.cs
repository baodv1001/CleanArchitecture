using hrm_core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost(Name = "Admin-SeedData")]
        public async Task<ActionResult> SeedSampleData()
        {
            await _adminService.SeedSampleData();

            return Ok();
        }
    }
}