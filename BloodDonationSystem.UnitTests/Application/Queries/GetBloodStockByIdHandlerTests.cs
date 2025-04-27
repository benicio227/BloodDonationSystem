using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Queries.GetBloodStockById;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Queries;
public class GetBloodStockByIdHandlerTests
{
    [Fact]
    public async Task GetBloodStockById_ReturnsSuccess_WhenBloodStockIsFound()
    {
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStockId = 1;
        var bloodStock = new BloodStock
        (
            "A+",
            "R-",
            470,
            1000 
        );

       
        repository.GetById(bloodStockId).Returns(bloodStock);

        var handler = new GetBloodStockByIdHandler(repository);
        var query = new GetBloodStockByIdQuery(bloodStockId);

       
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal("A+", result.Data.BloodType);
    }

    [Fact]
    public async Task GetBloodStockById_ReturnsError_WhenBloodStockNotFound()
    {
        var repository = Substitute.For<IBloodStockRepository>();
        
        var bloodStockId = 99;
        repository.GetById(bloodStockId).Returns(Task.FromResult<BloodStock>(null!));

        var handler = new GetBloodStockByIdHandler(repository);
        var query = new GetBloodStockByIdQuery(bloodStockId);

       
        var result = await handler.Handle(query, CancellationToken.None);

        
        Assert.False(result.IsSuccess);
        Assert.Equal("Estoque não encontrado com o ID fornecido.", result.Message);
    }
}
