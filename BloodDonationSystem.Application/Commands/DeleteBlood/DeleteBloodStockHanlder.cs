using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteBlood;
public class DeleteBloodStockHanlder : IRequestHandler<DeleteBloodStockCommand, ResultViewModel>
{
    private readonly IBloodStockRepository _repository;

    public DeleteBloodStockHanlder(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        var success = await _repository.Delete(request.Id);

        if (!success)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Estoque de sanque com ID {request.Id} não encontrado.");
        }

        return ResultViewModel.Success();
    }
}
