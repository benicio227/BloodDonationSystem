using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertUser;
public class InsertUserCommand : IRequest<ResultViewModel<UserViewModel>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RgFactor RgFactor { get; set; }


    public User ToEntity(string hash)
    {
        return new User(Email, hash, Role);
    }
}
