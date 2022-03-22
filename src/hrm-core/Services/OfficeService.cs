using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Offices;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;

namespace hrm_core.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<IEnumerable<Office>> GetAll()
        {
            return await _officeRepository.GetAll();
        }

        public async Task<Office> Create(IOfficeCreateRequest office)
        {
            var newOffice = new Office()
            {
                OfficeId = Guid.NewGuid(),
                Name = office.Name,
                Area = office.Area,
                CreatedDate = DateTime.Now,
                CreatedBy = "Postman"
            };
            return await _officeRepository.Create(newOffice);
        }

        public async Task<Office> GetById(Guid id)
        {
            return await _officeRepository.GetById(id);
        }
    }
}
