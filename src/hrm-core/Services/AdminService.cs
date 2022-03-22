using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Services;

namespace hrm_core.Services
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly ICommonRepository _commonRepository;
        public AdminService(ICommonRepository commonRepository):base(commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task SeedSampleData()
        {
            await _commonRepository.SeedSampleData();
        }
    }
}
