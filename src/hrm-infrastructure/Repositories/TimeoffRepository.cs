using AutoMapper;
using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Responses.Approvers;
using hrm_core.Responses.Dateoffs;
using hrm_core.Responses.Requests;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class TimeoffRepository : ITimeoffRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimeoffRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Approve(Guid id, Guid userId,  string updatedDate)
        {
            var dbRequest = await _dbContext.Requests.FindAsync(id);

            if(dbRequest.UpdatedDate != null && dbRequest.UpdatedDate.ToString() != updatedDate)
            {
                return false;
            }    
            dbRequest.Status = (int)RequestStatuses.Approved;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Create(Timeoff timeoff)
        {
            var dbRequest = _mapper.Map<RequestEntity>(timeoff);
            _dbContext.Requests.Add(dbRequest);
            await _dbContext.SaveChangesAsync();

            _dbContext.Entry(dbRequest).Reference(c => c.Employee).Load();
            _dbContext.Entry(dbRequest).Reference(c => c.RequestModel).Load();
            _dbContext.Entry(dbRequest).Collection(c => c.RequestDateoffs).Load();

            return true;
        }

        public async Task<RequestGetAllResponse> GetAll(RequestGetAllParameters requestParameters)
        {
            var total = (await _dbContext.Requests
                            .Where(e => e.Status == requestParameters.Status
                                        && e.RequestModelId == requestParameters.RequestModelId)
                            .ToListAsync()).Count;

            /*var requests = await _dbContext.Requests
                            .Include(item => item.RequestModel)
                                .ThenInclude(item => item.Approvers)
                            .Include(item => item.Employee)
                                .ThenInclude(item => item.Personal)
                            .Include(item => item.Employee)
                                .ThenInclude(item => item.User)
                            .Include(item => item.RequestDateoffs)
                                .ThenInclude(item => item.Dateoff)
                            .Where(e => e.Status == requestParameters.Status
                                        && e.RequestModelId == requestParameters.RequestModelId)
                            .Skip(requestParameters.PageSize * (requestParameters.PageNumber - 1))
                            .Take(requestParameters.PageSize)
                            .ToListAsync()
                            .ConfigureAwait(false);*/


            var request = await _dbContext.Requests.Join(_dbContext.RequestModels, request => request.RequestModelId, requestModel => requestModel.RequestModelId, (request, requestModel) => new RequestGetResponse
            {
                RequestModelName = requestModel.Name,
                Approvers = requestModel.Approvers.Select(approver => new ApproverGetResponse
                {
                    Avatar = approver.Employee.Avatar,
                    Name = approver.Employee.Personal.FirstName + ' ' + approver.Employee.Personal.LastName,
                    EmployeeEmail = approver.Employee.User.Email,
                    EmployeeId = approver.EmployeeId
                }).ToList(),
                RequestId= request.RequestId,
                RequestModelId = requestModel.RequestModelId,
                Deadline = requestModel.Deadline,
                 DistanceDays = requestModel.DistanceDays,
                LimitDays = requestModel.LimitDays,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                EmployeeId = (Guid)request.EmployeeId,
                EmployeeName = request.Employee.Personal.FirstName + ' ' + request.Employee.Personal.LastName,
                CreatedDate = request.CreatedDate,  
                UpdatedDate = (DateTime)request.UpdatedDate,
                RequestDateoffs = request.RequestDateoffs.Select(dateoff=> new DateoffGetResponse
                {
                    DateoffId = dateoff.DateoffId,
                    Name = dateoff.Dateoff.Name,
                    OffDate = dateoff.Dateoff.OffDate,
                    AfternoonFlg = dateoff.Dateoff.AfternoonFlg,
                    MorningFlg = dateoff.Dateoff.MorningFlg,
                    CreatedDate = dateoff.Dateoff.CreatedDate,
                    UpdatedDate = dateoff.Dateoff.UpdatedDate
                }).ToList(),
            }).Where(e => e.Status == requestParameters.Status
                                        && e.RequestModelId == requestParameters.RequestModelId)
                            .Skip(requestParameters.PageSize * (requestParameters.PageNumber - 1))
                            .Take(requestParameters.PageSize)
                            .ToListAsync()
                            .ConfigureAwait(false);


            return new RequestGetAllResponse()
            {
                Requests = _mapper.Map<IEnumerable<RequestGetResponse>>(request),
                Total = total
            };
        }

        public Task<RequestGetResponse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Reject(Guid id, Guid userId, string updatedDate)
        {
            var dbRequest = await _dbContext.Requests.FindAsync(id);

            if (dbRequest.UpdatedDate != null && dbRequest.UpdatedDate.ToString() != updatedDate)
            {
                return false;
            }
            dbRequest.Status = (int)RequestStatuses.Rejected;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
