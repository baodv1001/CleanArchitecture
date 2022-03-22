using Azure.Identity;
using hrm_api.Authorization;
using hrm_api.Helper;
using hrm_core.Enums;
using hrm_core.Helper;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Requests.Employees;
using hrm_core.Responses.Employees;
using hrm_infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace hrm_api.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminRequire")]
    [AppAuthorize(AllowedRoles = new[] { RoleType.ADMIN, RoleType.EMPLOYEE })]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        protected AppSettings _config;

        public EmployeeController(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
            // Read application settings from appsettings.json (tenant ID, app ID, client secret, etc.)
            _config = AppSettingsFile.ReadFromJsonFile();
        }

        [HttpGet(Name = "Employee-GetAll")]
        public async Task<ActionResult<EmployeeGetAllResponse>> GetAll([FromQuery] EmployeeGetAllParameters employeeParameters)
        {
            var response = await _employeeService.GetAll(employeeParameters).ConfigureAwait(false);

            return response != null ? Ok(response) : NoContent();
        }   

        [HttpPost(Name = "Employee-Create")]
        public async Task<ActionResult<Employee>> Create(EmployeeCreateRequest employee)
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };
            var clientSecretCredential = new ClientSecretCredential(_config.TenantId, _config.ClientId, _config.ClientSecret);
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

            var newUser = await _userService.BulkCreate(_config, graphClient, employee);

            var response = await _employeeService.Create(employee, newUser);

            if (response.EmployeeId == Guid.Empty)
            {
                return BadRequest("Error");
            }

            return CreatedAtRoute("Employee-Create", new { id = response.EmployeeId }, response);
        }

        [HttpGet("{id}", Name = "Employee-GetById")]
        public async Task<ActionResult<EmployeeGetResponse>> GetById(Guid id)
        {
            var response = await _employeeService.GetById(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }

        [HttpPut("{id}", Name = "Employee-Edit")]
        public async Task<ActionResult<Employee>> Edit(Guid id, EmployeeUpdateRequest employee)
        {
            var response = await _employeeService.Update(id, employee).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }

        [HttpDelete("{id}", Name = "Employee-Delete")]
        public async Task<ActionResult<Employee>> DeleteById(Guid id)
        {
            var response = await _employeeService.Delete(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NoContent();
        }
    }
}

