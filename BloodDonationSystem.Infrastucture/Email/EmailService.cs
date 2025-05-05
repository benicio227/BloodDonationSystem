using BloodDonationSystem.Core.Repositories;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BloodDonationSystem.Infrastucture.Email;
public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var apiKey = _configuration["SendGrid:ApiKey"]; //Pega chave do da API do SendGrid
        var client = new SendGridClient(apiKey); // Instancia um cliente SendGrid que será usado para enviar email
        var from = new EmailAddress("beniciobrandao@hotmail.com", "Blood Donation System"); // Define quem vai receber o email
        var to = new EmailAddress(toEmail); // Define quem vai receber o email
        var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
        await client.SendEmailAsync(msg); // Envia o email de forma assíncrona usando a API do SendGrid
    }
}
