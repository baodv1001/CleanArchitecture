using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Departments;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;

namespace hrm_core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _departmentRepository.GetAll();
        }

        public async Task<Department> Create(IDepartmentCreateRequest department)
        {
            var newDepartment = new Department()
            {
                DepartmentId = Guid.NewGuid(),
                Name = department.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = "Postman"
            };
            return await _departmentRepository.Create(newDepartment);
        }

        public async Task<Department> GetById(Guid id)
        {
            return await _departmentRepository.GetById(id);
        }
    }
}
