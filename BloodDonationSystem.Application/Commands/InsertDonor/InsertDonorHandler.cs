using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonor;
public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, DonorViewModel>
{
    private readonly IDonorRepository _repository;

    public InsertDonorHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<DonorViewModel> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = request.ToEntity();

        var donorExist = await _repository.Add(donor);

        var model = DonorViewModel.FromEntity(donor);

        return model;
    }
}
