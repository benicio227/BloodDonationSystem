using System.Security.Cryptography.Xml;

namespace BloodDonationSystem.Application.Models;
public class LoginViewModel
{
    public LoginViewModel(string token)
    {
        Token = token;
    }
    public string Token {  get; set; }

    public static LoginViewModel FromEntity(string token)
    {
        return new LoginViewModel(token);
    }
}
