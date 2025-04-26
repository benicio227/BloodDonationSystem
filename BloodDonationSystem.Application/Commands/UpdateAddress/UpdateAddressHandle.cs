using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.UpdateAddress;
public class UpdateAddressHandle : IRequestHandler<UpdateAddressCommand, ResultViewModel>
{
    private readonly IAddressRepository _repository;

    public UpdateAddressHandle(IAddressRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _repository.GetById(request.Id);

        if (address is null)
        {
            return ResultViewModel.Error("Endereço não encontrado.");
        }

        address.UpdateStreet(request.Street);
        address.UpdateCity(request.City);
        address.UpdateState(request.State);

        var updatedAddress =  await _repository.Update(address.Id);

        if (updatedAddress is null)
        {
            return ResultViewModel.Error($"Erro ao atualizar o endereço.");
        }

        return ResultViewModel.Success();
    }
}
