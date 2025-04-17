using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertBlood;
public class InsertBloodStockHandler : IRequestHandler<InsertBloodStockCommand, BloodStockViewModel>
{
    private readonly IBloodStockRepository _repsoitory;

    public InsertBloodStockHandler(IBloodStockRepository repository)
    {
        _repsoitory = repository;
    }
    public async Task<BloodStockViewModel> Handle(InsertBloodStockCommand request, CancellationToken cancellationToken)
    {
        var bloodStock = request.ToEntity();

        var bloodExist = await _repsoitory.Add(bloodStock);

        var model = BloodStockViewModel.FromEntity(bloodStock);

        return model;
    }
}
