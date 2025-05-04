using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.LoginUser;
public class LoginUserCommand : IRequest<ResultViewModel<LoginViewModel>>
{
    public string Email {  get; set; }
    public string Password { get; set; }
}
