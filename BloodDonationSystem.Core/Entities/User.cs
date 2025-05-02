using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Core.Entities;
public class User
{
    public User(int id, string email, string password, string role)
    {
        Id = id;
        Email = email;
        Password = password;
        Role = role;
        IsDeleted = false;
    }

    public int Id { get; private set; }
    public string Email {  get; private set; }
    public string Password {  get; private set; }
    public string Role { get; private set; } = "Donor";
    public bool IsDeleted { get; private set; }

    public Donor Donor { get; private set; }

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }


}
