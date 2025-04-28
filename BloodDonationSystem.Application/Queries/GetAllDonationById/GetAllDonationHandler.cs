using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAllDonationById;
public class GetAllDonationHandler : IRequestHandler<GetAllDonationQuery, ResultViewModel<List<DonationViewModel>>>
{
    private readonly IDonationRepository _repository;

    public GetAllDonationHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
    {
        var donations = await _repository.GetAll(request.Id);

        if (donations is null || !donations.Any())
        {
            return ResultViewModel<List<DonationViewModel>>.Error($"Nenhuma doação encontrada.");
        }

        var models = donations
            .Where(d => !d.IsDeleted) // Se quiser filtrar excluídos aqui também
            .Select(DonationViewModel.FromEntity)
            .ToList();

        return ResultViewModel<List<DonationViewModel>>.Success(models);
    }
}
