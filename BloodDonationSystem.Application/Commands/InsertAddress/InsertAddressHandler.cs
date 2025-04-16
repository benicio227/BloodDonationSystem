using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAddress;
public class InsertAddressHandler : IRequestHandler<InsertAddressCommand, AddressViewModel>
{
    private readonly IAddressRepository _repository;

    public InsertAddressHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<AddressViewModel> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
    {
        var address = request.ToEntity();

        var addressExist = await _repository.Add(address);

        var model = AddressViewModel.FromEntity(address);

        return model;
    }
}
