using BloodDonationSystem.Application.Commands.DeleteBlood;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class DeleteBloodStockHandlerTests
{
    [Fact]
    public async Task Handler_WhenDeleteBloodStock_Should_ReturnsSuccess()
    {
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStock = new BloodStock(
            "A+",
            "R-",
            470,
            1000
         );

        typeof(BloodStock).GetProperty(nameof(BloodStock.Id))!.SetValue(bloodStock, 1);

        repository.Delete(bloodStock.Id).Returns(true);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(bloodStock.Id);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);


    }

    [Fact]
    public async Task Handler_WhenBloodStockNotFound_Should_ReturnsError()
    {
      
        var repository = Substitute.For<IBloodStockRepository>();

        repository.Delete(Arg.Any<int>()).Returns(false);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(99);

   
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal($"Estoque de sanque com ID {command.Id} não encontrado.", result.Message);
    }

    [Fact]
    public async Task Handler_WhenAlreadyDeleteBloodStock_Should_ReturnsError()
    {
   
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStock = new BloodStock(
            "B-",
            "R-",
            470,
            1000
        );

        typeof(BloodStock).GetProperty(nameof(BloodStock.Id))!.SetValue(bloodStock, 2);
        typeof(BloodStock).GetProperty(nameof(BloodStock.IsDeleted))!.SetValue(bloodStock, true);

        repository.Delete(bloodStock.Id).Returns(false);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(bloodStock.Id);

     
        var result = await handler.Handle(command, CancellationToken.None);


        Assert.False(result.IsSuccess);
        Assert.Equal("Estoque foi excluído.", result.Message);
    }
}
