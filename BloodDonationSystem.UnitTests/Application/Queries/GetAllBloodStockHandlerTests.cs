using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Queries.GetAllBloodStock;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Queries;
public class GetAllBloodStockHandlerTests
{
    [Fact]
    public async Task GetAllBloodStock_ReturnsSuccess_WhenBloodStocksAreFound()
    {
        // Arrange
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStocks = new List<BloodStock>
        {
            new BloodStock ("A+", "R+", 0, 1000 ),
            new BloodStock ("B-", "R-", 0, 1000 )
        };

        
        repository.GetAll().Returns(bloodStocks);

        var handler = new GetAllBloodStockHandler(repository);
        var query = new GetAllBloodStockQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("A+", result[0].BloodType);
        Assert.Equal("B-", result[1].BloodType);
    }

    [Fact]
    public async Task GetAllBloodStock_ReturnsEmptyList_WhenNoBloodStocksAreFound()
    {
        var repository = Substitute.For<IBloodStockRepository>();
       
        var bloodStocks = new List<BloodStock>(); 
        repository.GetAll().Returns(bloodStocks);

        var handler = new GetAllBloodStockHandler(repository);
        var query = new GetAllBloodStockQuery();

        
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Empty(result);
    }
}
