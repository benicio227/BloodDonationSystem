using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;
using System.Runtime.CompilerServices;

namespace BloodDonationSystem.Application.Queries.GetDonorById;
public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, DonorViewModel>
{
    private readonly IDonorRepository _repository;

    public GetDonorByIdHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<DonorViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById(request.Id);

        var model = DonorViewModel.FromEntity(donor!);

        return model;
    }
}
