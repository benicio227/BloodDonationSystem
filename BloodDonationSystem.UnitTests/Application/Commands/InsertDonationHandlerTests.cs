using BloodDonationSystem.Application.Commands.InsertDonation;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class InsertDonationHandlerTests
{
    [Fact]
    public async Task Handle_WhenInputDataIsValid_ShouldInsertDonationSuccessfully()
    {
        var donationRepository = Substitute.For<IDonationRepository>();
        var donorRepository = Substitute.For<IDonorRepository>();
        var bloodStockRepository = Substitute.For<IBloodStockRepository>();

        var donor = new Donor
        (
            "João Silva",
            "joao@email.com",
            DateTime.Today.AddYears(-25),
            "Masculino",
            75,
            "A",
            "R+"
        );

        typeof(Donor)
            .GetProperty(nameof(Donor.Id))!
            .SetValue(donor, 1);

        var command = new InsertDonationCommand
        {
            DonorId = donor.Id,
            AmountMl = 500
        };

        var donation = command.ToEntity();

        var bloodStock = new BloodStock
        (
            "A+",
            "R+",
            1000,
            1500
        );

        typeof(Donation)
            .GetProperty(nameof(Donation.Id))!
            .SetValue(donation, 1);

        donorRepository.GetById(donor.Id).Returns(donor);
        donationRepository.GetLastDonationByDonorId(donor.Id).Returns((Donation)null!);
        donationRepository.Add(Arg.Any<Donation>()).Returns(donation);
        bloodStockRepository.GetByTypeAndFactor(donor.BloodType, donor.RgFactor).Returns(bloodStock);
        bloodStockRepository.Update(bloodStock).Returns(Task.CompletedTask);

        var handler = new InsertDonationHandler(donationRepository, donorRepository, bloodStockRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Single(donor.Donations);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(donation.Id, result.Data!.Id);
        Assert.True(string.IsNullOrEmpty(result.Message));
    }
}
