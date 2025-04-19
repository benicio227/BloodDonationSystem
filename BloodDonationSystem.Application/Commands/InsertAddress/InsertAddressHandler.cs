using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAddress;
public class InsertAddressHandler : IRequestHandler<InsertAddressCommand, ResultViewModel<AddressViewModel>>
{
    private readonly IAddressRepository _repository;

    public InsertAddressHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<AddressViewModel>> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
    {
        var address = request.ToEntity();

        var addressExist = await _repository.Add(address);

        if (addressExist is null)
        {
            return ResultViewModel<AddressViewModel>.Error($"Nenhum ID {request.DonorId} foi encontrado.");
        }

        var model = AddressViewModel.FromEntity(address);

        return ResultViewModel<AddressViewModel>.Success(model);
    }
}
