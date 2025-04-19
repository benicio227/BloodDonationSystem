using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertBlood;
public class InsertBloodStockHandler : IRequestHandler<InsertBloodStockCommand, ResultViewModel<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _repsoitory;

    public InsertBloodStockHandler(IBloodStockRepository repository)
    {
        _repsoitory = repository;
    }
    public async Task<ResultViewModel<BloodStockViewModel>> Handle(InsertBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = request.ToEntity();

        var bloodExist = await _repsoitory.Add(bloodStock);

        if (bloodExist is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Nenhum estoque com ID {bloodExist!.Id}");
        }

        var model = BloodStockViewModel.FromEntity(bloodStock);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
