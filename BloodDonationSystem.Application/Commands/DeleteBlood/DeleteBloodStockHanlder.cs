using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

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
        var bloodStock = await _repository.Delete(request.Id);

        if (bloodStock is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Estoque de sanque com ID {request.Id} não encontrado.");
        }

        if (bloodStock.IsDeleted)
        {
            return ResultViewModel<BloodStockViewModel>.Error("Estoque foi excluído.");
        }

        var model = BloodStockViewModel.FromEntity(bloodStock);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
