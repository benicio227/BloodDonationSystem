using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Events;
using BloodDonationSystem.Core.Repositories;

using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, ResultViewModel<DonationViewModel>>
{
    private readonly IDonationRepository _repository;
    private readonly IDonorRepository _donorRepository;
    private readonly IBloodStockRepository _bloodStockrepository;
    private readonly IMediator _mediator;
    private readonly IBrevoEmailService _brevoEmailService;
    public InsertDonationHandler(
        IDonationRepository repository,
        IDonorRepository donorRepository,
        IBloodStockRepository bloodStockRepository,
        IMediator mediator,
        IBrevoEmailService brevoEmailService)
    {
        _repository = repository;
        _donorRepository = donorRepository;
        _bloodStockrepository = bloodStockRepository;
        _mediator = mediator;
        _brevoEmailService = brevoEmailService;
    }
    public async Task<ResultViewModel<DonationViewModel>> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetById(request.DonorId);

        if (donor is null)
        {
            return ResultViewModel<DonationViewModel>.Error($"Nenhum id {request.DonorId} encontrado.");
        }

        var validResult =  await ValidateDonationInterval(donor.Id, donor.Gender.ToString());

        if (validResult is not null)
        {
            return validResult;
        }

        var data18Year = donor.BirthDate.AddYears(18);

        if (DateTime.Today < data18Year)
        {
            return ResultViewModel<DonationViewModel>.Error("O doador precisa ter 18 anos ou mais para doar sangue.");
        }

        var bloodStock = await _bloodStockrepository.GetByTypeAndFactor(donor.BloodType.ToString(), donor.RgFactor.ToString());

        if (bloodStock is null)
        {
            return ResultViewModel<DonationViewModel>.Error("Estoque não encontrado para esse tipo sanguíneo.");
        }

        var donation = request.ToEntity();

        await _repository.Add(donation);

        await _mediator.Publish(new DonationRegisteredDomainEvent(
            donor.Email,
            donor.FullName,
            donation.AmountMl
        ), cancellationToken);


        bloodStock.AddAmount(donation.AmountMl);

        await _bloodStockrepository.Update(bloodStock);

        var model = DonationViewModel.FromEntity(donation);

        if (bloodStock.AmountMl < bloodStock.MinimumAmountMl)
        {
            var warnings = new List<string>
            {
                $"O estoque de sangue do tipo {donor.BloodType}{donor.RgFactor} está abaixo do mínimo {bloodStock.MinimumAmountMl}ml disponível."
            };

            var domainEvent = new BloodStockBelowMinimumDomainEvent(
                donor.BloodType.ToString(),
                donor.RgFactor.ToString(),
                bloodStock.AmountMl,
                bloodStock.MinimumAmountMl
            );

            await _mediator.Publish(domainEvent, cancellationToken);

            return ResultViewModel<DonationViewModel>.SuccessWithWarnings(model, warnings);
        }


        return ResultViewModel<DonationViewModel>.Success(model);
    }

    private async Task<ResultViewModel<DonationViewModel>?> ValidateDonationInterval(int donorId, string gender)
    {
        var lastDonation = await _repository.GetLastDonationByDonorId(donorId);

        if (lastDonation is not null)
        {
            var daysSinceLastDonation = (DateTime.Today - lastDonation.DonationDate).TotalDays;

            if (gender == "Feminino" && daysSinceLastDonation < 90)
            {
                return ResultViewModel<DonationViewModel>.Error("Mulheres só podem doar sangue a cada 90 dias.");
            }
            
            if (gender == "Masculino" && daysSinceLastDonation < 60)
            {
                return ResultViewModel<DonationViewModel>.Error("Homens só podem doar sangue a cada 60 dias."); 
            }
        }

        return null;
    }
}
