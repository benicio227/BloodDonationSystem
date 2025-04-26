using BloodDonationSystem.Application.Commands.InsertBlood;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application;
public class InsertBloodStockHandlerTests
{
    [Fact]
    public async Task BloodStockExists_Insert_Success()
    {
        //Arrange
        var repository = Substitute.For<IBloodStockRepository>();

        var command = new InsertBloodStockCommand
        {
            BloodType = "A+",
            RgFactor = "R-",
            AmountMl = 0,
            MinimumAmountMl = 1000
        };

        var bloodStock = command.ToEntity();

        repository.GetByTypeAndFactor(command.BloodType, command.RgFactor).Returns((BloodStock)null!);

        repository.Add(Arg.Any<BloodStock>()).Returns(bloodStock);

        var handler = new InsertBloodStockHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(command.BloodType, result.Data!.BloodType);
        Assert.Equal(command.RgFactor, result.Data.RgFactor);
        Assert.Equal(command.AmountMl, result.Data.AmountMl);
        
    }

    [Fact]
    public async Task AlreadyExistsBloodStock_With_Same_BloodTypeAndRgFactor()
    {
        var repository = Substitute.For<IBloodStockRepository>();

        var command = new InsertBloodStockCommand
        {
            BloodType = "A+",
            RgFactor = "R+",
            AmountMl = 0,
            MinimumAmountMl = 1000
        };

        var bloodStock = command.ToEntity();

        repository.GetByTypeAndFactor(command.BloodType, command.RgFactor).Returns(bloodStock);

        var handler = new InsertBloodStockHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal("Já existe estoque com o tipo sanguíneo informado.", result.Message);
    }

    [Fact]
    public async Task Add_ReturnsNull_ShouldReturnError()
    {
        var repository = Substitute.For<IBloodStockRepository>();

        var command = new InsertBloodStockCommand
        {
            BloodType = "A+",
            RgFactor = "R-",
            AmountMl = 0,
            MinimumAmountMl = 1000
        };

        var bloodStock = command.ToEntity();

        repository.GetByTypeAndFactor(command.BloodType, command.RgFactor).Returns((BloodStock)null!);

        repository.Add(Arg.Any<BloodStock>()).Returns((BloodStock)null!);

        var handler = new InsertBloodStockHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal("Erro ao adicionar estoque de sangue.", result.Message);
    }
}
