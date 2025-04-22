using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;

namespace BloodDonationSystem.Application.Commands.DeleteDonor;
public class DeleteDonorByIdHandler : IRequestHandler<DeleteDonorByIdCommand, ResultViewModel>
{
    private readonly IDonorRepository _repository;

    public DeleteDonorByIdHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteDonorByIdCommand request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById(request.Id);

        if (donor == null)
        {
            return ResultViewModel.Error("Doador não encontrado.");
        }

        await _repository.Delete(donor.Id);

        return ResultViewModel.Success();
    }
}
