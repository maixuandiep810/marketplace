using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using marketplace.Utilities.Const;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace marketplace.Services.SystemManager.User
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
 
        public async Task SendEmailAsync(string email, string subject, string messageContent)
        {
            string fromMail = _configuration[ConfigKeyConst.FROM_EMAIL];
            string fromPassword = _configuration[ConfigKeyConst.FROM_PASSWORD];
 
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = messageContent;
            // message.Body ="<html><body> " + htmlMessage + " </body></html>";
            // message.IsBodyHtml = true;
            await Task.Delay(1);
            var smtpClient = new SmtpClient(_configuration[ConfigKeyConst.STMP_CLIENT])
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
 
    }
}