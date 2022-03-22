using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Employees;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonalRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Personal> Create(Personal personal)
        {
            var dbPersonal = _mapper.Map<PersonalEntity>(personal);
            _dbContext.Personals.Add(dbPersonal);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Personal>(dbPersonal);
        }

        public async Task<Personal> GetById(Guid id)
        {
            var personal = await _dbContext.Personals.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<Personal>(personal);
        }

        public async Task Update(IEmployeeUpdateRequest personal, Guid? personalId)
        {
            var dbPersonal = _dbContext.Personals.Find(personalId);

            _mapper.Map(personal, dbPersonal);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Personal> Find(Guid? id)
        {
            var personal = await _dbContext.Personals.Where(p => p.PersonalId == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<Personal>(personal);
        }
    }
}
