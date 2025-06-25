using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Auth;
using MediatR;

namespace BloodDonationSystem.Application.Commands.LoginUser;
internal class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginViewModel>>
{
    private readonly IAuthService _authService;
    private readonly ILoginRepository _loginRepository;
    public LoginUserHandler(IAuthService authService, ILoginRepository loginRepository)
    {
        _authService = authService;
        _loginRepository = loginRepository;
    }
    public async Task<ResultViewModel<LoginViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hash = _authService.ComputeHash(request.Password);

        var user = await _loginRepository.Login(request.Email, hash);

        if (user is null)
        {
            return ResultViewModel<LoginViewModel>.Error("Erro de login.");
        }

        var token = _authService.GenerateToken(user.Email, user.Role.ToString());

        var model = LoginViewModel.FromEntity(token);

        return ResultViewModel<LoginViewModel>.Success(model);
    }
}
