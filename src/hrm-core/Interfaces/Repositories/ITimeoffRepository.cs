using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Responses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Interfaces.Repositories
{
    public interface ITimeoffRepository
    {
        Task<bool> Create(Timeoff request);
        Task<RequestGetAllResponse> GetAll(RequestGetAllParameters employeeParameters);
        Task<RequestGetResponse> GetById(Guid id);
        Task<bool> Approve(Guid id, Guid userId,string updatedDate);
        Task<bool> Reject(Guid id, Guid userId, string updatedDate);
    }
}
