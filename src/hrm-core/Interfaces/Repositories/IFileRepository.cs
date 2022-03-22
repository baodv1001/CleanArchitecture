using hrm_core.DomainModels;
using Microsoft.AspNetCore.Http;

namespace hrm_core.Interfaces.Repositories
{
    public interface IFileRepository
    {
        Task<string> UploadImage(IFormFile file, AzureBlobStorageConfig config);
        Task<string> GetAvatar(Guid id);
    }
}
