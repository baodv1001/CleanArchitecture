using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public OfficeRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Office>> GetAll()
        {
            var offices = await _dbContext.Offices.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Office>>(offices);
        }

        public async Task<Office> Create(Office office)
        {
            var dbOffice = _mapper.Map<OfficeEntity>(office);
            _dbContext.Offices.Add(dbOffice);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Office>(dbOffice);
        }

        public async Task<Office> GetById(Guid id)
        {
            var office = await _dbContext.Offices.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<Office>(office);
        }
    }
}
