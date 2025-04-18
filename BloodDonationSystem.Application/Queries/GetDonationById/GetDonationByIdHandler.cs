using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetDonationById;
public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, DonationViewModel>
{
    private readonly IDonationRepository _repository;

    public GetDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<DonationViewModel> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var donation = await _repository.GetById(request.Id);


        var model = DonationViewModel.FromEntity(donation!);

        return model;
    }
}
