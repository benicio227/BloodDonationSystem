namespace BloodDonationSystem.Core.Repositories;
public interface IBrevoEmailService
{
    public Task SendEmail(string toEmail, string toName, string subject, string htmlContent);
}
