using Azure.Storage.Blobs;
using hrm_core.DomainModels;
using hrm_core.Interfaces.Repositories;
using hrm_infrastructure.Context;
using Microsoft.AspNetCore.Http;

namespace hrm_infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly HRMDbContext _dbContext;

        public FileRepository(HRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<string> GetAvatar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadImage(IFormFile file, AzureBlobStorageConfig config)
        {
            var containerClient = new BlobContainerClient(config.ConnectionString, config.Container);
            var blobClient = containerClient.GetBlobClient(file.FileName);

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                // Upload the file
                ms.Position = 0;
                await blobClient.UploadAsync(ms, overwrite: true);
            }

            var url = blobClient.Uri.ToString();

            return await Task.FromResult(url);
        }
    }
}
