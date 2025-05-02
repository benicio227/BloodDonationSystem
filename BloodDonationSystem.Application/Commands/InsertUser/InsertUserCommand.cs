using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Entities;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertUser;
public class InsertUserCommand : IRequest<ResultViewModel<UserViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "Donor";
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string RgFactor { get; set; }


    public User ToEntity()
    {
        return new User(Email, Password, Role);
    }
}
