using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<DonationViewModel>>
{
    private readonly IDonationRepository _repository;
    private readonly IDonorRepository _donorRepository;
    public InsertDonationHandler(IDonationRepository repository, IDonorRepository donorRepository)
    {
        _repository = repository;
        _donorRepository = donorRepository;
    }
    public async Task<ResultViewModel<DonationViewModel>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetById(request.DonorId);

        if (donor is null)
        {
            return ResultViewModel<DonationViewModel>.Error($"Nenhum id {request.DonorId} encontrado.");
        }

        await ValidateDonationInterval(donor.Id, donor.Gender);

        var data18Year = donor.BirthDate.AddYears(18);

        if (DateTime.Today < data18Year)
        {
            return ResultViewModel<DonationViewModel>.Error("O doador precisa ter 18 anos ou mais para doar sangue.");
        }

        var donation = request.ToEntity();

        await _repository.Add(donation);

        var model = DonationViewModel.FromEntity(donation);

        return ResultViewModel<DonationViewModel>.Success(model);
    }

    private async Task ValidateDonationInterval(int donorId, string gender)
    {
        var lastDonation = await _repository.GetLastDonationByDonorId(donorId);

        if (lastDonation is not null)
        {
            var daysSinceLastDonation = (DateTime.Today - lastDonation.DonationDate).TotalDays;

            if (gender == "Feminino" && daysSinceLastDonation < 90)
            {
                throw new Exception("Mulheres só podem doar sangue a cada 90 dias.");
            }
            
            if (gender == "Masculino" && daysSinceLastDonation < 60)
            {
                throw new Exception("Homens só pode doar sangue a cada 60 dias."); 
            }
        }
    }
}
