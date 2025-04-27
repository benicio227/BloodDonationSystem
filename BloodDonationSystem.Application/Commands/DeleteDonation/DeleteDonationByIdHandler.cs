using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteDonation;
public class DeleteDonationByIdHandler : IRequestHandler<DeleteDonationByIdQuery, ResultViewModel>
{
    private readonly IDonationRepository _repository;

    public DeleteDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteDonationByIdQuery request, CancellationToken cancellationToken)
    {
        var success = await _repository.Delete(request.Id);

        if (!success)
        {
            return ResultViewModel<DonationViewModel>.Error($"Doação com ID {request.Id} não encontrado.");
        }

        return ResultViewModel.Success();
    }
}
