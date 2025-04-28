using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllBloodStock;
public class GetAllBloodStockHandler : IRequestHandler<GetAllBloodStockQuery,ResultViewModel<List<BloodStockViewModel>>>
{
    private readonly IBloodStockRepository _repository;

    public GetAllBloodStockHandler(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
    {
        var bloodStocks = await _repository.GetAll();

        if (bloodStocks is null || !bloodStocks.Any())
        {
            return ResultViewModel<List<BloodStockViewModel>>.Error("Nenhum estoque de sangue encontrado.");
        }

        var bloodStockViewModels = bloodStocks.Select(BloodStockViewModel.FromEntity).ToList();

        return ResultViewModel<List<BloodStockViewModel>>.Success(bloodStockViewModels);
    }
}
