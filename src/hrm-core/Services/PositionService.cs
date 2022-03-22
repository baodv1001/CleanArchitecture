using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Positions;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;

namespace hrm_core.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _positionRepository.GetAll();
        }

        public async Task<Position> Create(IPositionCreateRequest position)
        {
            var newPosition = new Position()
            {
                PositionId = Guid.NewGuid(),
                Name = position.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = "Postman"
            };
            return await _positionRepository.Create(newPosition);
        }

        public async Task<Position> GetById(Guid id)
        {
            return await _positionRepository.GetById(id);
        }
    }
}
