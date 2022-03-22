using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;

namespace hrm_infrastructure.Repositories
{
    public class DateoffRepository : IDateoffRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public DateoffRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> Create(List<Dateoff> dateoffs)
        {
            foreach(var dateoff in dateoffs)
            {
                var dbRequest = _mapper.Map<DateoffEntity>(dateoff);
                _dbContext.Dateoffs.Add(dbRequest);
                _dbContext.Entry(dbRequest).Collection(c => c.RequestDateoffs).Load();
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
