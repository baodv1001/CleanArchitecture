using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.EmployeeTypes;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;

namespace hrm_core.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        public async Task<IEnumerable<EmployeeType>> GetAll()
        {
            return await _employeeTypeRepository.GetAll();
        }

        public async Task<EmployeeType> Create(IEmployeeTypeCreateRequest employeeType)
        {
            var newEmployee = new EmployeeType()
            {
                EmployeeTypeId = Guid.NewGuid(),
                TypeName = employeeType.TypeName,
                CreatedDate = DateTime.Now,
                CreatedBy = "Postman"
            };
            return await _employeeTypeRepository.Create(newEmployee);
        }

        public async Task<EmployeeType> GetById(Guid id)
        {
            return await _employeeTypeRepository.GetById(id);
        }
    }
}
