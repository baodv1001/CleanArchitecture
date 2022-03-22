using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Requests.EmployeeTypes;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeService _employeeTypeService;

        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            _employeeTypeService = employeeTypeService;
        }

        [HttpGet(Name = "EmployeeType-GetAll")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var response = await _employeeTypeService.GetAll().ConfigureAwait(false);

            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost(Name = "EmployeeType-Create")]
        public async Task<ActionResult<Position>> Create(EmployeeTypeCreateRequest employeeType)
        {
            var response = await _employeeTypeService.Create(employeeType).ConfigureAwait(false);

            if (response.EmployeeTypeId == Guid.Empty)
            {
                return BadRequest();
            }
            return CreatedAtRoute("EmployeeType-Create", new { id = response.EmployeeTypeId }, response);
        }

        [HttpGet("{id}", Name = "EmployeeType-GetById")]
        public async Task<ActionResult<Department>> GetById(Guid id)
        {
            var response = await _employeeTypeService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
