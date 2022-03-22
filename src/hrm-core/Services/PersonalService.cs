using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;

namespace hrm_core.Services
{

    public class PersonalService : IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonalService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public async Task<Personal> GetById(Guid id)
        {
            return await _personalRepository.GetById(id);
        }
    }

}
