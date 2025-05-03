using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Auth;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertUser;
public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDonorRepository _donorRepository;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IDonorRepository donorRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _donorRepository = donorRepository; 
        _authService = authService;

    }
    public async Task<ResultViewModel<UserViewModel>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var hash = _authService.ComputeHash(request.Password);

        var user = request.ToEntity(hash);

        var alreadyExistUserEmail = await _userRepository.GetByEmail(request.Email);

        if (alreadyExistUserEmail is not null)
        {
            return ResultViewModel<UserViewModel>.Error("Já existe um usuário com esse E-mail.");
        }

        await _userRepository.Add(user);

        var donor = new Donor(
             request.FullName,
             request.BirthDate,
             request.Gender,
             request.Weight,
             request.BloodType,
             request.RgFactor,
             user.Id
        );

        await _donorRepository.Add(donor);

        var model = UserViewModel.FromEntity(donor);

        return ResultViewModel<UserViewModel>.Success(model);
    }
}
