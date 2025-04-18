using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using MediatR;

namespace BloodDonationSystem.Application.Commands.InsertDonation;
public class InsertDonationHandler : IRequestHandler<InsertDonationCommand, DonationViewModel>
{
    private readonly IDonationRepository _repository;
    private readonly IDonorRepository _donorRepository;
    public InsertDonationHandler(IDonationRepository repository, IDonorRepository donorRepository)
    {
        _repository = repository;
        _donorRepository = donorRepository;
    }
    public async Task<DonationViewModel> Handle(InsertDonationCommand request, CancellationToken cancellationToken)
    {
        var donor = await _donorRepository.GetById(request.DonorId);

        var data18Year = donor.BirthDate.AddYears(18);

        if (DateTime.Today < data18Year)
        {
            throw new Exception("O doador precisa ter 18 anos ou mais para doar sangue.");
        }

        var donation = request.ToEntity();

        await _repository.Add(donation);

        var model = DonationViewModel.FromEntity(donation);

        return model;
    }
}
