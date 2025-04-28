using BloodDonationSystem.Application.Commands.UpdateAddress;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class UpdateAddressHandlerTests
{
    [Fact]
    public async Task Handler_WhenAddressExists_Should_Update()
    {
        var repository = Substitute.For<IAddressRepository>();

        var existingAddress = new Address(1, "Rua antiga", "Cidade antiga", "UF", "12345-678");

        var command = new UpdateAddressCommand
        {
            Id = existingAddress.Id,
            Street = "Rua nova",
            City = "Cidade nova",
            State = "UF"
        };

        repository.GetById(existingAddress.Id).Returns(existingAddress);

        repository.Update(existingAddress).Returns(true);

        var handler = new UpdateAddressHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.True(result.IsSuccess);
        Assert.True(string.IsNullOrEmpty(result.Message));
    }

    [Fact]
    public async Task Handler_WhenAddressNotFound_Should_ReturnError()
    {
        var repository = Substitute.For<IAddressRepository>();


        var command = new UpdateAddressCommand
        {
            Id = 999,
            Street = "Nova Rua",
            City = "Nova Cidade",
            State = "UF"
        };

        repository.GetById(command.Id).Returns((Address)null!);

        var handler = new UpdateAddressHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal("Endereço não encontrado.", result.Message);
    }

    [Fact]
    public async Task Handler_WhenUpdateFails_Should_ReturnError()
    {
        var repository = Substitute.For<IAddressRepository>();

        var existingAddress = new Address(1, "Rua Antiga", "Cidade Antiga", "UF", "1234556");

        var command = new UpdateAddressCommand
        {
            Id = existingAddress.Id,
            Street = "Nova Rua",
            City = "Nova Cidade",
            State = "UF"
        };

        repository.GetById(command.Id).Returns(existingAddress);

        repository.Update(existingAddress).Returns(false);

        var handler = new UpdateAddressHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal($"Erro ao atualizar o endereço.", result.Message);
    }
}
