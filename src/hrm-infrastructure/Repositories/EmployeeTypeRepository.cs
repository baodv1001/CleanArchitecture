using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeTypeRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeType>> GetAll()
        {
            var employeeTypes = await _dbContext.EmployeeTypes.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<EmployeeType>>(employeeTypes);
        }

        public async Task<EmployeeType> Create(EmployeeType employeeType)
        {
            var dbEmployeeType = _mapper.Map<EmployeeTypeEntity>(employeeType);
            _dbContext.EmployeeTypes.Add(dbEmployeeType);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeType>(dbEmployeeType);
        }

        public async Task<EmployeeType> GetById(Guid id)
        {
            var employeeType = await _dbContext.EmployeeTypes.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<EmployeeType>(employeeType);
        }
    }
}
