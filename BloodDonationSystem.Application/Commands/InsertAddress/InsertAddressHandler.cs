using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Cep;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertAddress;
public class InsertAddressHandler : IRequestHandler<InsertAddressCommand, ResultViewModel<AddressViewModel>>
{
    private readonly IAddressRepository _repository;
    private readonly ICepService _cepService;

    public InsertAddressHandler(IAddressRepository repository, ICepService cepService)
    {
        _repository = repository;
        _cepService = cepService;
    }
    public async Task<ResultViewModel<AddressViewModel>> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
    {

        var cepInfo = await _cepService.ConsultarCepAsync(request.Cep);

        if (cepInfo is null)
        {
            return ResultViewModel<AddressViewModel>.Error("CEP inválido ou não encontrado.");
        }

        var street = !string.IsNullOrWhiteSpace(cepInfo.Logradouro)
            ?cepInfo.Logradouro
            : string.IsNullOrWhiteSpace(request.Street) || request.Street!.ToLower() == "string"
                ? null
                : request.Street;

        if (string.IsNullOrWhiteSpace(street))
        {
            return ResultViewModel<AddressViewModel>.Error("Não foi possível encontrar o nome da rua.");
        }

        var address = new Address
        (
            request.DonorId,
            street,
            cepInfo.Localidade,
            cepInfo.Uf,
            request.Cep
        );

        var addedAddress = await _repository.Add(address);

        if (addedAddress is null)
        {
            return ResultViewModel<AddressViewModel>.Error($"Erro ao adicionar o endereço para o ID {request.DonorId}.");
        }

        var model = AddressViewModel.FromEntity(addedAddress);

        return ResultViewModel<AddressViewModel>.Success(model);
    }
}
