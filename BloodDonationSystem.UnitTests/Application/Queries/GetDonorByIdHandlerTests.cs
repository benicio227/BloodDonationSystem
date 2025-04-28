using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Queries.GetDonorById;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Queries;
public class GetDonorByIdHandlerTests
{
    [Fact]
    public async Task Handle_WhenDonorExists_ShouldReturnDonorSuccessfully()
    {
        var repository = Substitute.For<IDonorRepository>();

        var donor = new Donor(
            "Benício Brandão",
            "beniciobrandao@hotmail.com",
            new DateTime(1994, 4, 7),
            "Masculino",
            57,
            "A+",
            "R-"
        );

        repository.GetById(Arg.Any<int>()).Returns(donor);

        var handler = new GetDonorByIdHandler(repository);

        var command = new GetDonorByIdQuery(1);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(donor.FullName, result.Data?.FullName);
    }

    [Fact]
    public async Task Handle_WhenDonorNotFound_ShouldReturnError()
    {
       
        var repository = Substitute.For<IDonorRepository>();

       
        repository.GetById(Arg.Any<int>()).Returns((Donor?)null);

        var handler = new GetDonorByIdHandler(repository);
        var command = new GetDonorByIdQuery(1);

       
        var result = await handler.Handle(command, CancellationToken.None);

    
        Assert.False(result.IsSuccess);
        Assert.Equal("Doador com ID 1 não encontrado.", result.Message);
    }

    [Fact]
    public async Task Handle_WhenDonorIsDeleted_ShouldReturnError()
    {
      
        var repository = Substitute.For<IDonorRepository>();
        var donor = new Donor(
            "Benício Brandão",
            "beniciobrandao@hotmail.com",
            new DateTime(1994, 4, 7),
            "Masculino",
            57,
            "A+",
            "R-"
        );


        typeof(Donor).GetProperty("IsDeleted")?.SetValue(donor, true);


        repository.GetById(Arg.Any<int>()).Returns(donor);

        var handler = new GetDonorByIdHandler(repository);
        var command = new GetDonorByIdQuery(1); 

     
        var result = await handler.Handle(command, CancellationToken.None);

    
        Assert.False(result.IsSuccess);
        Assert.Equal("Este doador foi excluído.", result.Message);
    }
}
