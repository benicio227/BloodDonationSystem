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
    
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStocks = new List<BloodStock>
        {
            new BloodStock ("A+", "R+", 0, 1000 ),
            new BloodStock ("B-", "R-", 0, 1000 )
        };

        
        repository.GetAll().Returns(bloodStocks);

        var handler = new GetAllBloodStockHandler(repository);
        var query = new GetAllBloodStockQuery();

     
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.NotEmpty(result.Data);
        Assert.Equal(2, result.Data.Count);
        Assert.Equal("A+", result.Data[0].BloodType);
        Assert.Equal("B-", result.Data[1].BloodType);
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

        Assert.Empty(result.Data);
    }
}
