using System.Net;
using System.Net.Mail;
using Application.Common.Interfaces;

namespace Infrastructure.Services;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string receptor, string Sub, string body)
    {
        var host = Environment.GetEnvironmentVariable("HOST");
        var port = Environment.GetEnvironmentVariable("PORT");
        var emailUser = Environment.GetEnvironmentVariable("EMAIL");
        var password = Environment.GetEnvironmentVariable("PASSWORD");

        var smtpClient = new SmtpClient(host, int.Parse(port ?? "0"));
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;

        smtpClient.Credentials = new NetworkCredential(emailUser, password);
        string Subject = Sub;
        string Body = body;
        var message = new MailMessage(emailUser ?? "error@fmf.com", receptor, Subject, Body)
        {
            IsBodyHtml = true
        };
        await smtpClient.SendMailAsync(message);
    }
}