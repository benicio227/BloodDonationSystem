namespace BloodDonationSystem.Infrastucture.Auth;
public interface IAuthService
{
    public string ComputeHash(string password);
    public string GenerateToken(string email, string role);
}
