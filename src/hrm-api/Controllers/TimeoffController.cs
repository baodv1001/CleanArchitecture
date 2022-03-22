using hrm_core.Interfaces.Requests.Timeoffs;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Requests.Timeoffs;
using hrm_core.Responses.Employees;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeoffController : ControllerBase
    {
        private readonly ITimeoffService _timeoffService;

        public TimeoffController(ITimeoffService timeoffService)
        {
            _timeoffService = timeoffService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create(TimeoffCreateRequest request)
        {
            var response = await _timeoffService.Create(request).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPost("approve")]
        public async Task<ActionResult<bool>> Approve(TimeoffApproveRequest request)
        {
            var response = await _timeoffService.Approve(request).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpPost("reject")]
        public async Task<ActionResult<bool>> Reject(TimeoffApproveRequest request)
        {
            var response = await _timeoffService.Reject(request).ConfigureAwait(false);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeGetAllResponse>> GetAll([FromQuery] RequestGetAllParameters parameters)
        {
            var response = await _timeoffService.GetAll(parameters).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
