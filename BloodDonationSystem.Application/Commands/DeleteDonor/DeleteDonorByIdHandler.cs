using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

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

        if (donor is null)
        {
            return ResultViewModel.Error("Doador não encontrado.");
        }

        var deleted = await _repository.Delete(donor.Id);

        if (!deleted)
        {
            return ResultViewModel.Error("Erro ao deletar o doador.");
        }

        return ResultViewModel.Success();
    }
}
