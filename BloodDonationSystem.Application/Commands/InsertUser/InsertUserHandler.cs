using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertUser;
public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<UserViewModel>>
{
    public Task<ResultViewModel<UserViewModel>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        var donor = new Donor(
             request.FullName,
             request.BirthDate,
             request.Gender,
             request.Weight,
             request.BloodType,
             request.RgFactor,
             user.Id
        );
    }
}
