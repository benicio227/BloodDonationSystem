using BloodDonationSystem.Application.Commands.InsertDonor;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class InsertDonorHandlerTests
{
    [Fact]
    public async Task Handle_WhenInputDataIsValid_ShouldInsertDonorSuccessfully()
    {
      
        var repository = Substitute.For<IDonorRepository>(); 
                                                             
        var donor = new Donor("João da Silva", "joao@email.com", new DateTime(1994, 4, 7), "Masculino", 80, "A+", "R-");

        repository.GetByEmail(donor.Email).Returns((Donor)null!);

        repository.Add(Arg.Any<Donor>()).Returns(donor);

        var command = new InsertDonorCommand
        {
            FullName = donor.FullName,
            Email = donor.Email,
            BirthDate = donor.BirthDate,
            Gender = donor.Gender,
            Weight = donor.Weight,
            BloodType = donor.BloodType,
            RgFactor = donor.RgFactor,
        };

        var handler = new InsertDonorHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.True(result.IsSuccess);

        Assert.NotNull(result.Data);

        Assert.Equal(command.FullName, result.Data.FullName);
    }


    [Fact]
    public async Task Handle_WhenDonorAlreadyExists_ShouldReturnError()
    {
        var repository = Substitute.For<IDonorRepository>();

        var existingDonor = new Donor("João da Silva", "joao@email.com", new DateTime(1994, 4, 7), "Masculino", 80, "A+", "R-");

        repository.GetByEmail(existingDonor.Email).Returns(existingDonor);

        var command = new InsertDonorCommand
        {
            FullName = existingDonor.FullName,
            Email = existingDonor.Email,
            BirthDate = existingDonor.BirthDate,
            Gender = existingDonor.Gender,
            Weight = existingDonor.Weight,
            BloodType = existingDonor.BloodType,
            RgFactor = existingDonor.RgFactor,
        };

        var handler = new InsertDonorHandler(repository);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess); 
        Assert.Null(result.Data);
        Assert.Equal("Já existe um doador com esse E-mail.", result.Message);
    }
}
