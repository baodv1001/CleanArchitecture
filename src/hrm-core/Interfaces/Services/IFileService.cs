using hrm_core.DomainModels;
using Microsoft.AspNetCore.Http;

namespace hrm_core.Interfaces.Services
{
    public interface IFileService
    {
        Task<string> UploadImage(IFormFile file, AzureBlobStorageConfig config);
        Task<string> GetAvatar(Guid id);
    }
}
