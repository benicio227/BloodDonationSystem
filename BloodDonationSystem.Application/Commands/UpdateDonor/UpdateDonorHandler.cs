using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.UpdateDonor;
public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
{
    private readonly IDonorRepository  _repository;

    public UpdateDonorHandler(IDonorRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = await _repository.GetById(request.Id);

        if (donor is null)
        {
            return ResultViewModel.Error("Doador não encontrado.");
        }

        donor.UpdateEmail(request.Email);
        donor.UpdateWeight(request.Weight);
        donor.UpdateBloodType(request.BloodType);
        donor.UpdateRgFactor(request.RgFactor);

        var updateSuccessfully = await _repository.Update(donor);

        if (!updateSuccessfully)
        {
            return ResultViewModel.Error("Não foi possível atualizar o doador.");
        }

        return ResultViewModel.Success();
    }
}
