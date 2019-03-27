using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace polozi_ba.Service
{
    public class EmailSender:IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient()
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("@gmail.com", ""),
                Port=587,
                Host= "smtp.gmail.com",
                EnableSsl=true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("@gmail.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            return client.SendMailAsync(mailMessage);
        }
    }
}
