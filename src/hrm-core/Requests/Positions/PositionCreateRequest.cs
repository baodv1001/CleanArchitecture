using hrm_core.Interfaces.Requests.Positions;

namespace hrm_core.Requests.Positions
{
    public class PositionCreateRequest : IPositionCreateRequest
    {
        public string Name { get; set; }
    }
}
