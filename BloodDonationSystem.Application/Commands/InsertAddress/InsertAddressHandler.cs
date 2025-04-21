using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Cep;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;

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

        var cepInfo = await _cepService.ConsultarCepAscyn(request.Cep);

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

        var addressExist = await _repository.Add(address);

        if (addressExist is null)
        {
            return ResultViewModel<AddressViewModel>.Error($"Nenhum ID {request.DonorId} foi encontrado.");
        }

        var model = AddressViewModel.FromEntity(address);

        return ResultViewModel<AddressViewModel>.Success(model);
    }
}
