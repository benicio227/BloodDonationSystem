using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.DeleteAddressById;
public class DeleteAddressByIdHandler : IRequestHandler<DeleteAddressByIdQuery, ResultViewModel>
{
    private readonly IAddressRepository _repository;

    public DeleteAddressByIdHandler(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var success = await _repository.Delete(request.Id);

        if (success is null)
        {
            return ResultViewModel<AddressViewModel>.Error("Nehum endereço com esse id foi encontrado.");
        }

        return ResultViewModel.Success();
    }
}
