using BloodDonationSystem.Application.Commands.DeleteAddressById;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class DeleteAddressHandlerTests
{
    [Fact]
    public async Task Handler_WhenAddressExists_Should_Delete()
    {
        var repository = Substitute.For<IAddressRepository>();

        var address = new Address(2, "Rua das flores", "Aracaju", "SE", "123465");


        repository.Delete(address.Id).Returns(address);

        var query = new DeleteAddressByIdQuery(address.Id);

        var handler = new DeleteAddressByIdHandler(repository);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.True(result.IsSuccess);
        Assert.True(string.IsNullOrEmpty(result.Message));
    }

    [Fact]
    public async Task Handler_WhenAddressNotFound_Should_ReturnError()
    {
        var repository = Substitute.For<IAddressRepository>();

        int addressId = 1;

        repository.Delete(addressId).Returns((Address)null!);

        var query = new DeleteAddressByIdQuery(addressId);

        var handler = new DeleteAddressByIdHandler(repository);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal($"Nehum endereço com esse id foi encontrado.", result.Message);
       
    }
}
