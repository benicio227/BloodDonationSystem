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

        var bloodStockExist = await _repsoitory.GetByTypeAndFactor(request.BloodType, request.RgFactor);

        if (bloodStockExist is not null)
        {
            return ResultViewModel<BloodStockViewModel>.Error("Já existe estoque com o tipo sanguíneo informado.");
        }

        var bloodExist = await _repsoitory.Add(bloodStock);

        if (bloodExist is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Erro ao adicionar estoque de sangue.");
        }

        var model = BloodStockViewModel.FromEntity(bloodStock);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
