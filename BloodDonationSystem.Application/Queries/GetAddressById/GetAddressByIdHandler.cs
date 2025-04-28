using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAddressById;
public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, ResultViewModel<AddressViewModel>>
{
    private readonly IAddressRepository _repository;

    public GetAddressByIdHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<AddressViewModel>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _repository.GetById(request.Id);

        if (address is null || address.IsDeleted)
        {
            return ResultViewModel<AddressViewModel>.Error("Endereço não encontrado.");
        }

        var model = AddressViewModel.FromEntity(address);

        return ResultViewModel<AddressViewModel>.Success(model);
    }
}
