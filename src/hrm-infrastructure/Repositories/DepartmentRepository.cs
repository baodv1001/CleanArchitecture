using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var departments = await _dbContext.Departments.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Department>>(departments);
        }

        public async Task<Department> Create(Department department)
        {
            var dbDepartment = _mapper.Map<DepartmentEnity>(department);
            _dbContext.Departments.Add(dbDepartment);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Department>(dbDepartment);
        }

        public async Task<Department> GetById(Guid id)
        {
            var department = await _dbContext.Departments.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<Department>(department);
        }
    }
}
