using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteDonationById;
public class DeleteDonationByIdHandler : IRequestHandler<DeleteDonationByIdQuery, Unit>
{
    private readonly IDonationRepository _repository;

    public DeleteDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteDonationByIdQuery request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.Id);

        return Unit.Value;
    }
}
