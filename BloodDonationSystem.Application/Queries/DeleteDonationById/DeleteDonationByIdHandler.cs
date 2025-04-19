using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteDonationById;
public class DeleteDonationByIdHandler : IRequestHandler<DeleteDonationByIdQuery, ResultViewModel<DonationViewModel>>
{
    private readonly IDonationRepository _repository;

    public DeleteDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<DonationViewModel>> Handle(DeleteDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var donation = await _repository.Delete(request.Id);

        if (donation is null)
        {
            return ResultViewModel<DonationViewModel>.Error($"Doação com ID {request.Id} não encontrado.");
        }

        var model = DonationViewModel.FromEntity(donation);

        return ResultViewModel<DonationViewModel>.Success(model);
    }
}
