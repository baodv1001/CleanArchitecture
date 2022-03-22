using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Timeoffs;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Responses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Services
{
    public class TimeoffService : ITimeoffService
    {
        private readonly ITimeoffRepository _timeoffRepository;
        private readonly IDateoffRepository _dateoffRepository;
        private readonly IRequestDateoffRepository _requestDateoffRepository;
        private readonly ISendMailService _sendMailService;

        public TimeoffService(ITimeoffRepository timeoffRepository, ISendMailService sendMailService, IDateoffRepository dateoffRepository, IRequestDateoffRepository requestDateoffRepository)
        {
            _timeoffRepository = timeoffRepository;
            _sendMailService = sendMailService;
            _dateoffRepository = dateoffRepository;
            _requestDateoffRepository = requestDateoffRepository;
        }

        public async Task<bool> Approve(ITimeoffApproveRequest request)
        {
            var res = await _timeoffRepository.Approve(request.RequestId, request.UserId,request.UpdatedDate);
            if (!res)
            {
                return false;

            }

            MailContent mailContent = new()
            {
                Body = "Your request is approved",
                Subject = "REQUEST RESPONSE",
                To = new List<Guid>{ request.UserId }
            };
            return await _sendMailService.SendMail(mailContent).ConfigureAwait(false);
        }

        public async Task<bool> Reject(ITimeoffApproveRequest request)
        {
            var res = await _timeoffRepository.Reject(request.RequestId, request.UserId, request.UpdatedDate);
            if (!res)
            {
                return false;

            }

            MailContent mailContent = new()
            {
                Body = "Your request is rejected",
                Subject = "REQUEST RESPONSE",
                To = new List<Guid> { request.UserId }
            };
            return await _sendMailService.SendMail(mailContent).ConfigureAwait(false);
        }

        public async Task<bool> Create(ITimeoffCreateRequest request)
        {
            var timeoff = new Timeoff
            {
                RequestId = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                EmployeeId = request.EmployeeId,
                Status = 1,
                Attachments = request.Attachments?.ToArray(),
                RequestModelId = request.RequestModelId,
                CreatedBy = "Me",
                CreatedDate = DateTime.Now,
            };


            var res = await _timeoffRepository.Create(timeoff);
            if (!res)
            {
                return false;

            }

            var dateoffs = new List<Dateoff>();
            foreach (var dateoff in request.Dateoffs)
            {
                dateoffs.Add(new Dateoff()
                {
                    DateoffId = Guid.NewGuid(),
                    OffDate = dateoff.OffDate,
                    Name = dateoff.Name,
                    MorningFlg = dateoff.MorningFlg,
                    AfternoonFlg = dateoff.AfternoonFlg,
                    CreatedBy = "Me",
                    CreatedDate = DateTime.Now
                });
            }

            res = await _dateoffRepository.Create(dateoffs);

            if (!res)
            {
                return false;

            }

            var requestDateoffs = new List<RequestDateoff>();

            foreach (var dateoff in dateoffs)
            {
                requestDateoffs.Add(new RequestDateoff()
                {
                    DateoffId = dateoff.DateoffId,
                    RequestId = timeoff.RequestId,
                });
            }

            res = await _requestDateoffRepository.Create(requestDateoffs);

            if (!res)
            {
                return false;

            }

            MailContent mailContent = new()
            {
                Body = request.Description,
                Subject = request.Title,
                To = request.Approvers
            };
            return await _sendMailService.SendMail(mailContent).ConfigureAwait(false);

        }

        public async Task<RequestGetAllResponse> GetAll(RequestGetAllParameters employeeParameters)
        {
            return await _timeoffRepository.GetAll(employeeParameters);
        }

        public async Task<RequestGetResponse> GetById(Guid id)
        {
            return await _timeoffRepository.GetById(id);
        }
    }
}
