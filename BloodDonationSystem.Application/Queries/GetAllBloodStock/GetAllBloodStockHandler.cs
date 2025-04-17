using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllBloodStock;
public class GetAllBloodStockHandler : IRequestHandler<GetAllBloodStockQuery, List<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _repository;

    public GetAllBloodStockHandler(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<BloodStockViewModel>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
    {
        var bloodStocks = await _repository.GetAll();

        var bloodStockViewModel = bloodStocks.Select(bloodStock => BloodStockViewModel.FromEntity(bloodStock)).ToList(); ;

        return bloodStockViewModel;
    }
}
