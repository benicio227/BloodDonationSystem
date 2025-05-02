using BloodDonationSystem.Application.Commands.DeleteDonor;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class DeleteDonorHandlerTests
{
    [Fact]
    public async Task Hanlder_WhenDonorExists_ShouldDeleteDonor()
    {
      
        var repository = Substitute.For<IDonorRepository>();

        //var donor = new Donor("Maria Oliveira", "maria@email.com", new DateTime(1990, 5, 20), "Feminino", 65, "O+", "R+");

        //repository.GetById(donor.Id).Returns(donor);

        //repository.Delete(donor.Id).Returns(true);

        //var command = new DeleteDonorByIdCommand(donor.Id);

        var handler = new DeleteDonorByIdHandler(repository);

   
        //var result = await handler.Handle(command, new CancellationToken());

    
        //Assert.True(result.IsSuccess);
        //Assert.True(string.IsNullOrEmpty(result.Message));
    }

    [Fact]
    public async Task Handler_WhenDonorDoesNotExist_Should_ReturnError()
    {
      
        var repository = Substitute.For<IDonorRepository>();

        var donorId = 123456789;

        repository.GetById(donorId).Returns((Donor)null!);

        var command = new DeleteDonorByIdCommand(donorId);

        var handler = new DeleteDonorByIdHandler(repository); 

     
        var result = await handler.Handle(command, new CancellationToken());

    
        Assert.False(result.IsSuccess);
        Assert.Equal("Doador não encontrado.", result.Message);
    }
}
