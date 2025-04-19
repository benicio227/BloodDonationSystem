using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;

namespace BloodDonationSystem.Application.Commands.DeleteBlood;
public class DeleteBloodStockHanlder : IRequestHandler<DeleteBloodStockCommand, ResultViewModel<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _repository;

    public DeleteBloodStockHanlder(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<BloodStockViewModel>> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStockExist = await _repository.Delete(request.Id);

        if (bloodStockExist is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Estoque de sanque com ID {request.Id} não encontrado.");
        }

        var model = BloodStockViewModel.FromEntity(bloodStockExist);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
