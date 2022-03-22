using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Requests.Departments;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet(Name = "Department-GetAll")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            var response = await _departmentService.GetAll().ConfigureAwait(false);

            return response != null ? Ok(response) : NoContent();
        }

        [HttpPost(Name = "Department-Create")]
        public async Task<ActionResult<Department>> Create(DepartmentCreateRequest department)
        {
            var response = await _departmentService.Create(department).ConfigureAwait(false);

            if (response.DepartmentId == Guid.Empty)
            {
                return BadRequest();
            }
            return CreatedAtRoute("Department-Create", new { id = response.DepartmentId }, response);
        }

        [HttpGet("{id}", Name = "Department-GetById")]
        public async Task<ActionResult<Department>> GetById(Guid id)
        {
            var response = await _departmentService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}
