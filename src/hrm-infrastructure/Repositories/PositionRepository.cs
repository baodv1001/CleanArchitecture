using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public PositionRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            var positions = await _dbContext.Positions.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Position>>(positions);
        }

        public async Task<Position> Create(Position position)
        {
            var dbPosition = _mapper.Map<PositionEntity>(position);
            _dbContext.Positions.Add(dbPosition);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Position>(dbPosition);
        }

        public async Task<Position> GetById(Guid id)
        {
            var position = await _dbContext.Positions.FindAsync(id).ConfigureAwait(false);
            return _mapper.Map<Position>(position);
        }
    }
}
