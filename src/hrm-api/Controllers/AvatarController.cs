using hrm_core.DomainModels;
using hrm_core.Interfaces.Services;
using hrm_infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace hrm_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        private readonly ILogger<AvatarController> _logger;
        private readonly HRMDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IFileService _fileService;
        private readonly IEmployeeService _employeeService;
        public AvatarController(ILogger<AvatarController> logger, HRMDbContext dbContext, IConfiguration config, IFileService fileService, IEmployeeService employeeService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _config = config;
            _fileService = fileService;
            _employeeService = employeeService;
        }

        [HttpPut("{userId}", Name = "UploadAvatar")]
        public async Task<ActionResult<string>> UploadAvatar([FromForm] IFormFile file, Guid userId)
        {
            var azureBlobStorageConfig = new AzureBlobStorageConfig
            {
                ConnectionString = _config.GetValue<string>("AzureBlobStorage:ConnectionString"),
                Container = _config.GetValue<string>("AzureBlobStorage:Container"),
                AccountName = _config.GetValue<string>("AzureBlobStorage:AccountName"),
                SasToken = _config.GetValue<string>("AzureBlobStorage:SasToken")

            };

            var url = await _fileService.UploadImage(file, azureBlobStorageConfig).ConfigureAwait(false);
            var response = false;

            if (!string.IsNullOrEmpty(url))
            {
                response = await _employeeService.UpdateAvatar(url, userId);
            }

            return response != false ? Ok(url) : NoContent();
        }
    }
}
