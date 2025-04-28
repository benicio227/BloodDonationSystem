using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Queries.GetAddressById;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Queries;
public class GetAddressByIdHandlerTests
{
    [Fact]
    public async Task Handle_WhenAddressExistsAndNotFound_ShouldReturnAddressSuccessfully()
    {
        var repository = Substitute.For<IAddressRepository>();

        var address = new Address
        (
            1,
            "Rua A",
            "Cidade X",
            "Estado Y",
            "12345"
        );

        repository.GetById(1).Returns(address);

        var handler = new GetAddressByIdHandler(repository);

        var query = new GetAddressByIdQuery(1);

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal("Rua A", result.Data.Street);
        Assert.Equal("Cidade X", result.Data.City);
        Assert.Equal("Estado Y", result.Data.State);
    }

    [Fact]
    public async Task Handle_WhenAddressNotFound_ShouldReturnError()
    {
        
        var repository = Substitute.For<IAddressRepository>();

        repository.GetById(1).Returns((Address?)null!); 

        var handler = new GetAddressByIdHandler(repository);
        var query = new GetAddressByIdQuery(1);

       
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal("Endereço não encontrado.", result.Message);
    }

    [Fact]
    public async Task Handle_WhenBloodStockIsDeleted_ShouldReturnError()
    {
        var repository = Substitute.For<IAddressRepository>();
        
        var address = new Address
        (
            1,
            "Rua A",
            "Cidade X",
            "Estado Y",
            "123456"
         
        );

        typeof(Address).GetProperty(nameof(Address.IsDeleted))!.SetValue(address, true);

        repository.GetById(1).Returns(address);

        var handler = new GetAddressByIdHandler(repository);
        var query = new GetAddressByIdQuery(1);

       
        var result = await handler.Handle(query, CancellationToken.None);

      
        Assert.False(result.IsSuccess);
        Assert.Equal("Este endereço foi excluído.", result.Message);
    }


}
