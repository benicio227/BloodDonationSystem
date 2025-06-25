using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Core.Entities;
public class User
{
    public User(string email, string password, UserRole role)
    {
        Email = email;
        Password = password;
        Role = role;
        IsDeleted = false;
    }

    public int Id { get; private set; }
    public string Email {  get; private set; }
    public string Password {  get; private set; }
    public UserRole Role { get; private set; }
    public bool IsDeleted { get; private set; }

    public Donor? Donor { get; private set; } //Nem todo usuário precisa ser um doador, por isso ?

    public void UpdateEmail(string email)
    {
        Email = email;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
