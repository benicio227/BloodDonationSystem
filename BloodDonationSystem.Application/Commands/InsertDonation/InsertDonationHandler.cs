using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, DonationViewModel>
{
    private readonly IDonationRepository _repository;

    public InsertDonationHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<DonationViewModel> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = request.ToEntity();

        await _repository.Add(donation);

        var model = DonationViewModel.FromEntity(donation);

        return model;
    }
}
