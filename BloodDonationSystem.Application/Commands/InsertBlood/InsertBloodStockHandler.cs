using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertBlood;
public class InsertBloodStockHandler : IRequestHandler<InsertBloodStockCommand, ResultViewModel<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _repository;

    public InsertBloodStockHandler(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<BloodStockViewModel>> Handle(InsertBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = request.ToEntity();

        var existingBloodStock = await _repository.GetByTypeAndFactor(request.BloodType, request.RgFactor);

        if (existingBloodStock is not null)
        {
            return ResultViewModel<BloodStockViewModel>.Error("Já existe estoque com o tipo sanguíneo informado.");
        }


        var addedBloodStock = await _repository.Add(bloodStock);

        if (addedBloodStock is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error($"Erro ao adicionar o estoque de sangue.");
        }

        var model = BloodStockViewModel.FromEntity(addedBloodStock);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
