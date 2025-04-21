using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllDonationById;
public class GetAllDonationHandler : IRequestHandler<GetAllDonationQuery, ResultViewModel<List<Donation>>>
{
    private readonly IDonationRepository _repository;

    public GetAllDonationHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<Donation>>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
    {
        var donations = await _repository.GetAll(request.Id);

        if (donations is null || !donations.Any())
        {
            return ResultViewModel<List<Donation>>.Error($"Nenhum ID {request.Id} encontrado.");
        }

        return ResultViewModel<List<Donation>>.Success(donations!);
    }
}
