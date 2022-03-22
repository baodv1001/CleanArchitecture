using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.ExternalServices
{
    public class SendMailService : ISendMailService
    {
        private readonly MailSettings mailSettings;

        // mailSetting được Inject qua dịch vụ hệ thống
        // Có inject Logger để xuất log
        public SendMailService(IOptions<MailSettings> _mailSettings)
        {
            mailSettings = _mailSettings.Value;
        }

        // Gửi email, theo nội dung trong mailContent
        public async Task<bool> SendMail(MailContent mailContent)
        {
            var result = false;

            var email = new MimeMessage
            {
                Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail),
                Subject = mailContent.Subject,
            };
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            foreach(var approver in mailContent.To)
            {
                var mail = "vuratngu2001@gmail.com";
                email.To.Add(MailboxAddress.Parse(mail));
            }


            var builder = new BodyBuilder
            {
                HtmlBody = mailContent.Body
            };
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
                result = true;
            }
            catch (Exception)
            {
                throw;
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                /*Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);*/
            }
            finally
            {
                smtp.Disconnect(true);
            }
            return result;
        }
        public async Task SendEmailAsync(List<Guid> email, string subject, string htmlMessage)
        {
            await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }
    }
}
