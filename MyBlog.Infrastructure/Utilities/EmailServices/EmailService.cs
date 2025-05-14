using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyBlog.Application.Utilities.IEmailServices;

namespace MyBlog.Infrastructure.Utilities.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly bool _useEmailService;
        private readonly IConfiguration _configuration;
        


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _useEmailService = bool.TryParse(_configuration["EmailSettings:UseEmailService"], out var result) && result;
        }

        public bool UseEmailService => _useEmailService;

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {

            if (!_useEmailService)
            {
                return true; 
            }


            var fromEmail = _configuration["EmailSettings:FromEmail"];
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true,
                    
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        


    }
}
