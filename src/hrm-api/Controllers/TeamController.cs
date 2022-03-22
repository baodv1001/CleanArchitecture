using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Requests.Teams;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet(Name = "Team-GetAll")]
        public async Task<ActionResult<IEnumerable<Team>>> GetAll()
        {
            var response = await _teamService.GetAll().ConfigureAwait(false);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost(Name = "Team-Create")]
        public async Task<ActionResult<Team>> Create(TeamCreateRequest team)
        {

            var response = await _teamService.Create(team).ConfigureAwait(false);

            if (response.TeamId == Guid.Empty)
            {
                return BadRequest();
            }

            return CreatedAtRoute("Team-Create", new { id = response.TeamId }, response);
        }

        [HttpGet("{id}", Name = "Team-GetById")]
        public async Task<ActionResult<Team>> GetById(Guid id)
        {
            var response = await _teamService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
