using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Requests.Positions;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet(Name = "Position-GetAll")]
        public async Task<ActionResult<IEnumerable<Position>>> GetAll()
        {
            var response = await _positionService.GetAll().ConfigureAwait(false);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost(Name = "Position-Create")]
        public async Task<ActionResult<Position>> Create(PositionCreateRequest position)
        {

            var response = await _positionService.Create(position).ConfigureAwait(false);

            if (response.PositionId == Guid.Empty)
            {
                return BadRequest();
            }

            return CreatedAtRoute("Position-Create", new { id = response.PositionId }, response);
        }

        [HttpGet("{id}", Name = "Position-GetById")]
        public async Task<ActionResult<Position>> GetById(Guid id)
        {
            var response = await _positionService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
