using hrm_core.Interfaces.Requests.Timeoffs;
using hrm_core.Parameters;
using hrm_core.Requests.Timeoffs;
using hrm_core.Responses.Requests;

namespace hrm_core.Interfaces.Services
{
    public interface ITimeoffService
    {
        Task<bool> Create(ITimeoffCreateRequest request);
        Task<RequestGetAllResponse> GetAll(RequestGetAllParameters employeeParameters);
        Task<RequestGetResponse> GetById(Guid id);
        Task<bool> Approve(ITimeoffApproveRequest request);
        Task<bool> Reject(ITimeoffApproveRequest request);
    }
}
