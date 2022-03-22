using hrm_core.Interfaces.Repositories;
using hrm_core.Utils;

namespace hrm_core.Services
{
    public class BaseService
    {
        private readonly ICommonRepository _commonRepository;
        public BaseService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<string> GetNewEmployeeCode(Guid teamId)
        {
            var num = await _commonRepository.GetEmployeeNum();
            var prefix = await _commonRepository.GetDepartmentPrefix(teamId);

            return (prefix + CustomString.PadAnInt(num, 5)).ToString();
        }

        public async Task<Guid> GetBaseRole()
        {
            return await _commonRepository.GetBaseRole();
        }
    }
}
