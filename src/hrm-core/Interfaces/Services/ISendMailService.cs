using hrm_core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Interfaces.Services
{
    public interface ISendMailService
    {
        Task<bool> SendMail(MailContent mailContent);

        Task SendEmailAsync(List<Guid> email, string subject, string htmlMessage);
    }
}
