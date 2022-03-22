using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalController : Controller
    {
        private readonly IPersonalService _personalService;

        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet("{id}", Name = "Personal-GetById")]
        public async Task<ActionResult<Personal>> GetById(Guid id)
        {
            var response = await _personalService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
