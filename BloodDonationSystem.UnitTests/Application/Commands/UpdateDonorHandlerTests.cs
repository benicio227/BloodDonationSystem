using BloodDonationSystem.Application.Commands;
using BloodDonationSystem.Application.Commands.UpdateDonor;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class UpdateDonorHandlerTests
{
    [Fact]
    public async Task Handler_WhenDonorExists_Should_Update()
    {
        var repository = Substitute.For<IDonorRepository>();

        var donor = new Donor(
            "Benício Brandão",
            "beniciobrandao@hotmail.com",
            new DateTime(1994, 4, 7),
            "Masculino",
            57,
            "A+",
            "R-"
        );

        typeof(Donor).GetProperty(nameof(Donor.Id))!.SetValue(donor, 1);

        var command = new UpdateDonorCommand
        {
            Id = donor.Id
        };

        repository.GetById(donor.Id).Returns(donor);

        repository.Update(donor).Returns(true);

        var handler = new UpdateDonorHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task Handler_WhenNoDonorFound_Should_ReturnError()
    {
        var repository = Substitute.For<IDonorRepository>();

        var donor = new Donor(
            "Benício Brandão",
            "beniciobrandao@hotmail.com",
            new DateTime(1994, 4, 7),
            "Masculino",
            57,
            "A+",
            "R-"
        );

        typeof(Donor).GetProperty(nameof(Donor.Id))!.SetValue(donor, 1);

        repository.GetById(donor.Id).Returns((Donor?)null);

        var command = new UpdateDonorCommand
        {
            Id = donor.Id
        };

        var handler = new UpdateDonorHandler(repository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal("Doador não encontrado.", result.Message);
    }

    [Fact]
    public async Task Handler_WhenNoUpdateDonor_Should_ReturnsError()
    {
        var repository = Substitute.For<IDonorRepository>();

        var donor = new Donor(
            "Benício Brandão",
            "beniciobrandao@hotmail.com",
            new DateTime(1994, 4, 7),
            "Masculino",
            57,
            "A+",
            "R-"
        );

        typeof(Donor).GetProperty(nameof(Donor.Id))!.SetValue(donor, 1);

        repository.GetById(donor.Id).Returns(donor);

        repository.Update(Arg.Any<Donor>()).Returns(false);

        var command = new UpdateDonorCommand
        {
            Id = donor.Id
        };

        var handler = new UpdateDonorHandler(repository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal("Não foi possível atualizar o doador.", result.Message);
    }
}
