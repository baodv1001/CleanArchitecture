using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Requests.Offices;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet(Name = "Office-GetAll")]
        public async Task<ActionResult<IEnumerable<Office>>> GetAll()
        {
            var response = await _officeService.GetAll().ConfigureAwait(false);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost(Name = "Office-Create")]
        public async Task<ActionResult<Office>> Create(OfficeCreateRequest office)
        {

            var response = await _officeService.Create(office).ConfigureAwait(false);

            if (response.OfficeId == Guid.Empty)
            {
                return BadRequest();
            }

            return CreatedAtRoute("Office-Create", new { id = response.OfficeId }, response);
        }

        [HttpGet("{id}", Name = "Office-GetById")]
        public async Task<ActionResult<Office>> GetById(Guid id)
        {
            var response = await _officeService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
