using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAddressById;
public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressViewModel>
{
    private readonly IAddressRepository _repository;

    public GetAddressByIdHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<AddressViewModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _repository.GetById(request.Id);

        if (address is null)
        {
            throw new KeyNotFoundException("Endereço não encontrado");
        }

        var model = AddressViewModel.FromEntity(address);

        return model;
    }
}
