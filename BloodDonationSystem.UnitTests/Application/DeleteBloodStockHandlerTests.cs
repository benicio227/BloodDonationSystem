using BloodDonationSystem.Application.Commands.DeleteBlood;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application;
public class DeleteBloodStockHandlerTests
{
    [Fact]
    public async Task DeleteBloodStock_ReturnsSuccess_WhenDeletedSuccessfully()
    {
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStock = new BloodStock(
            "A+",
            "R-",
            470,
            1000
         );

        typeof(BloodStock).GetProperty(nameof(BloodStock.Id))!.SetValue(bloodStock, 1);

        repository.Delete(bloodStock.Id).Returns(bloodStock);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(bloodStock.Id);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(bloodStock.BloodType, result.Data.BloodType);

    }

        [Fact]
    public async Task DeleteBloodStock_ReturnsError_WhenBloodStockNotFound()
    {
        // Arrange
        var repository = Substitute.For<IBloodStockRepository>();

        repository.Delete(Arg.Any<int>()).Returns((BloodStock?)null);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(99);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal($"Estoque de sanque com ID {command.Id} não encontrado.", result.Message);
    }

    [Fact]
    public async Task DeleteBloodStock_ReturnsError_WhenAlreadyDeleted()
    {
        // Arrange
        var repository = Substitute.For<IBloodStockRepository>();

        var bloodStock = new BloodStock(
            "B-",
            "R-",
            470,
            1000
        );

        typeof(BloodStock).GetProperty(nameof(BloodStock.Id))!.SetValue(bloodStock, 2);
        typeof(BloodStock).GetProperty(nameof(BloodStock.IsDeleted))!.SetValue(bloodStock, true);

        repository.Delete(bloodStock.Id).Returns(bloodStock);

        var handler = new DeleteBloodStockHanlder(repository);

        var command = new DeleteBloodStockCommand(bloodStock.Id);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Estoque foi excluído.", result.Message);
    }
}
