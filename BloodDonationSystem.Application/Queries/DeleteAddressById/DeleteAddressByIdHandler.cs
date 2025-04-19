using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.DeleteAddressById;
public class DeleteAddressByIdHandler : IRequestHandler<DeleteAddressByIdQuery, ResultViewModel<AddressViewModel>>
{
    private readonly IAddressRepository _repository;

    public DeleteAddressByIdHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<AddressViewModel>> Handle(DeleteAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _repository.Delete(request.Id);

        if (address is null)
        {
            return ResultViewModel<AddressViewModel>.Error($"Nehum endereço com ID {request.Id} foi encontrado.");
        }

        var model = AddressViewModel.FromEntity(address);

        return ResultViewModel<AddressViewModel>.Success(model);
    }
}
