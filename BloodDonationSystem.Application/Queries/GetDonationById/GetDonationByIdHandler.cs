using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetDonationById;
public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationViewModel>>
{
    private readonly IDonationRepository _repository;

    public GetDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var donation = await _repository.GetById(request.Id);

        if (donation is null || donation.IsDeleted)
        {
            return ResultViewModel<DonationViewModel>.Error($"Doação com ID {request.Id} não encontrado.");
        }

        var model = DonationViewModel.FromEntity(donation);

        return ResultViewModel<DonationViewModel>.Success(model);
    }
}
