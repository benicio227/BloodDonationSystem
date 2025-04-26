using BloodDonationSystem.Application.Commands.DeleteDonor;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application;
public class DeleteDonorHandlerTests
{
    [Fact]
    public async Task DonorExists_Delete_Success()
    {
        // Arrange
        var repository = Substitute.For<IDonorRepository>();

        var donor = new Donor("Maria Oliveira", "maria@email.com", new DateTime(1990, 5, 20), "Feminino", 65, "O+", "R+");

        repository.GetById(donor.Id).Returns(donor);

        repository.Delete(donor.Id).Returns(donor);

        var command = new DeleteDonorByIdCommand
        {
            Id = donor.Id
        };

        var handler = new DeleteDonorByIdHandler(repository);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.True(result.IsSuccess);
        Assert.True(string.IsNullOrEmpty(result.Message));
    }

    [Fact]
    public async Task DonorDoesNotExist_ReturnsError()
    {
        // Arrange
        var repository = Substitute.For<IDonorRepository>();

        var donorId = 123456789;

        repository.GetById(donorId).Returns((Donor)null!);

        var command = new DeleteDonorByIdCommand
        {
            Id = donorId
        };

        var handler = new DeleteDonorByIdHandler(repository); // Passamos o repsoitorio fake, porque o repositorio de verdade chama o banco de dados de verdade

        //Act 
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Doador não encontrado.", result.Message);
    }
}
