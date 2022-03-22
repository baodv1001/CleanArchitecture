using hrm_core.DomainModels;

namespace hrm_core.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAll();

        Task<Position> Create(Position position);
        Task<Position> GetById(Guid id);
    }
}
