using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetBloodStockById;
public class GetBloodStockByIdHandler : IRequestHandler<GetBloodStockByIdQuery, ResultViewModel<BloodStockViewModel>>
{
    private readonly IBloodStockRepository _repository;

    public GetBloodStockByIdHandler(IBloodStockRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
    {
        var bloodStock = await _repository.GetById(request.Id);

        if (bloodStock is null)
        {
            return ResultViewModel<BloodStockViewModel>.Error("Estoque não encontrado com o ID fornecido.");
        }

        var model = BloodStockViewModel.FromEntity(bloodStock);

        return ResultViewModel<BloodStockViewModel>.Success(model);
    }
}
