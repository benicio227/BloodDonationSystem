using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteAddressById;
public class DeleteAddressByIdHandler : IRequestHandler<DeleteAddressByIdQuery, Unit>
{
    private readonly IAddressRepository _repository;

    public DeleteAddressByIdHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteAddressByIdQuery request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.Id);

        return Unit.Value;
    }
}
