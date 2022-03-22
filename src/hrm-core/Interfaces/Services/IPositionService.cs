using hrm_core.Interfaces.Requests.Positions;
using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Services
{
    public interface IPositionService
    {
        public Task<IEnumerable<Position>> GetAll();

        public Task<Position> Create(IPositionCreateRequest position);
        Task<Position> GetById(Guid id);
    }
}
