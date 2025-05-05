using BloodDonationSystem.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace BloodDonationSystem.Infrastucture.Email;
public class BrevoEmailService : IBrevoEmailService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public BrevoEmailService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Brevo:ApiKey"];
        Console.WriteLine(_apiKey);
    }

    public async Task SendEmail(string toEmail, string toName, string subject, string htmlContent)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.brevo.com/v3/smtp/email");

        request.Headers.Add("api-key", _apiKey);
        request.Headers.Add("accept", "application/json");

        var payload = new
        {
            sender = new { name = "Blood Donation System", email = "beniciobrandao@hotmail.com" },
            to = new[] { new { email = toEmail, name = toName } },
            subject = subject,
            htmlContent = htmlContent
        };

        var json = JsonSerializer.Serialize(payload);

        Console.WriteLine(json);

        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);

        Console.WriteLine($"📥 Status code da resposta: {response.StatusCode}");


        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Erro ao enviar e-mail: {response.StatusCode}, {body}");
        }
    }
}
