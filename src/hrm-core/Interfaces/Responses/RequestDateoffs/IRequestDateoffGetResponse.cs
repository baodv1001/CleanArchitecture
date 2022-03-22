using hrm_core.Responses.Dateoffs;

namespace hrm_core.Interfaces.Responses.RequestDateoffs
{
    public interface IRequestDateoffGetResponse
    {
        DateoffGetResponse Dateoff { get; set; }
        Guid DateoffId { get; set; }
    }
}
