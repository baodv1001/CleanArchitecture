using hrm_core.DomainModels;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace hrm_core.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<string> GetAvatar(Guid id)
        {
            return await _fileRepository.GetAvatar(id);
        }

        public async Task<string> UploadImage(IFormFile file, AzureBlobStorageConfig config)
        {
            return await _fileRepository.UploadImage(file, config);
        }
    }
}
