using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;
using System.Runtime.CompilerServices;

namespace BloodDonationSystem.Application.Queries.GetDonorById;
public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorViewModel>>
{
    private readonly IDonorRepository _repository;

    public GetDonorByIdHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById(request.Id);

        if (donor is null)
        {
            return ResultViewModel<DonorViewModel>.Error($"Doador com ID {request.Id} não encontrado.");
        }

        var model = DonorViewModel.FromEntity(donor!);

        return ResultViewModel<DonorViewModel>.Success(model);
    }
}
